using System;
using System.Collections.Generic;
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

        compterscience,
        Business,
        electricalEng,
        SWEngi,

    }

    /// <summary>
    /// This is a facory class
    /// </summary>
    static class CollegeRegistrar
    {
        #region properties
        /// <summary>
        /// Contains registred list of students at the college.
        /// </summary>


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
            var program = Programs.Where(p => p.ProgramName == programName).FirstOrDefault();
            program.RegisredStudentsList.Add(new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDay = birthDay,
                Type = type,
                Sex = sex,
            }); ;
        }
        static public void RegisterForCourse(HashSet<Course> course, Student student, semisterNames semister, SemisterYear year)
        {
            var program = Programs.Where(p => p.RegisredStudentsList.Contains(student)).FirstOrDefault();

            var courseavaliable = program.DisplayCoursesForYearPerSemister(semister, year);
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
            #endregion
        }
    }
}
