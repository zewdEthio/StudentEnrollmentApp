using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EnrollmentApp
{
    // Assume we have know number of course for each program .

    enum semisterNames
    {
        First,
        second,
        summer,
    }

    // Assume we have only four year program
    enum SemisterYear
    {
        FirstYear,
        SecondYear,
        thirdYear,
        ForthYear,
    }

    enum programsNames
        {
        [Description("Computer Science")] 
        compterscience,
        [Description("Business Adminstration")]
        BusinessAdmin,
        [Description("Electrical Enrineering")]
        electrical_Eng,
        [Description("Software Enrineering")]
        Software_Engi,

    }

    /// <summary>
    /// This is a facory class
    /// </summary>
    static class CollegeRegistrar
    {
        #region properties
        private static CollegeContext db = new CollegeContext();

        static public IEnumerable<Programs> Programs { get; set; }
        #endregion
        #region methods
        /// <summary>
        /// Enables to register student and add to list of registred students
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="birthDay"></param>
        /// <param name="type"></param>
        /// <param name="sex"></param>
        static public void EnrollStudent(string firstName, string lastName, DateTime birthDay, StudentType type, Gender sex, programsNames programName)
        {
           
            db.Students.Add(new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDay = birthDay,
                Type = type,
                Sex = sex,
                ProgramNames = programName,
            });
            db.SaveChanges();
        }
        static public void RegisterForCourse(HashSet<Course> course, Student student, semisterNames semister, SemisterYear year)
        {
            var program = Programs.Where(p => p.RegisredStudentsList.Contains(student)).FirstOrDefault();

            if (program != null) // if student is enrolled in aprogram
            {
                var courseavaliable =DisplayCoursesForYearPerSemister(semister, year,program.ProgramName);
                //TO DO: check registrar policy for the maximum number of course registred at atime for a simister.
                if (!course.All(i => student.RegistredCourses.Contains(i)) && course.All(i => courseavaliable.Contains(i)))
                {

                    student.RegistredCourses.Concat(course);
                }
                else
                {
                    Console.WriteLine("you already registed for this course or not avaliable");
                }
            }
            else
            {
                Console.WriteLine("please enroll in aprogramm");
            }
        }
       static public void DisplayAllProgramNames()
        {
            var names = Enum.GetNames(typeof(programsNames));
            foreach(var name in names)
            {
                Console.WriteLine(name);
            }
        }
        static public void DeropCourse(List<Course> course, Student student)
        {
            // TO DO : check some rules to drop a course
            if (course.All(i => student.RegistredCourses.Contains(i)))
            {
                student.RegistredCourses = student.RegistredCourses.Except(course).ToHashSet();
            }
            else
            {
                Console.WriteLine("you are not registred for this course");
            }
        }
        static public IEnumerable<Course> DisplayCoursesForYearPerSemister(semisterNames semister, SemisterYear year, programsNames program)
        {

            return Programs.Where(p => p.ProgramName ==program).FirstOrDefault().Courses.Where(c => c.semisterName == semister && c.Semisterbatch == year);


        }

        #endregion
    }
}
