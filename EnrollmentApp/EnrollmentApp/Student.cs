using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace EnrollmentApp
{
    enum StudentType
    {
        FullTime,
        PartTim
    }
    public enum Gender
    {
        Female,
        Male
    }

    /// <summary>
    /// This class is about a student who is going to be enrolled in a courses for a program
    /// </summary>
    class Student
    {
        private static int LastRegistredStudentId = 0;

        public Student()
        {
            Id = ++LastRegistredStudentId;
            DateOfRegistration = DateTime.UtcNow;
        }
        #region Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public StudentType Type { get; set; }
        public Gender Sex { get; set; }
        public HashSet<Course>RegistredCourses {get; set;}
        #endregion
        #region method
        public void RegisterForCourse(HashSet<Course> course)
        {
            //TO DO: check registrar policy for the maximum number of course registred at atime for a simister.
            if (!course.All(i => this.RegistredCourses.Contains(i)))
                {
                this.RegistredCourses.Concat(course);
                }
            else
            {
                Console.WriteLine("you already registed for this course");
            }
        }

        public void DeropCourse(List<Course> course)
        {
            if (course.All(i => this.RegistredCourses.Contains(i)))
            {
                this.RegistredCourses = this.RegistredCourses.Except(course).ToHashSet();
            }
           else
           {
                Console.WriteLine("you are not registred for this course");
            }
        #endregion
    }
}
