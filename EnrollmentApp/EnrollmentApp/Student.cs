using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Course>RegistredCourses {get; set;}
        #endregion

    }
}
