using System;
using System.Collections.Generic;
using System.Text;

namespace EnrollmentApp
{
   /// <summary>
   /// This class is about a student who is going to be enrolled in a courses for a program
   /// </summary>
    class Student
    {
        private static int LastRegistredStudentId = 0;
        #region constructor
        public Student()
        {
            Id=++LastRegistredStudentId;
        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay{ get; set; }
        public DateTime DateOfRegistration { get; set; }
        public char Sex{ get; set; }
        public Programs program { get; set; }
        public HashSet<Course> RegistredCourses { get; set; }
        #endregion

        #region Method
        public void Apply(string firstName,string lastName,DateTime birthday,DateTime dateOfregisteration, Programs program)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDay = birthday;
            this.DateOfRegistration = dateOfregisteration;
            this.program = program;
        }
        public void RegisterForCourse(Course course)
        {
            this.RegistredCourses.Add(course);
        }

        #endregion


    }
}
