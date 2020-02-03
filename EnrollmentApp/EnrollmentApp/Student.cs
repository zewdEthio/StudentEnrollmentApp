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
        public int MaximumCrteditHourPerSemister = 20;
        public int MinumumCreditHourPerSemister = 5;
        public Student()
        {
            Id = ++LastRegistredStudentId;
            DateOfEnrollement = DateTime.UtcNow;
        }
        #region Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime DateOfEnrollement { get; set; }
        public StudentType Type { get; set; }
        public Gender Sex { get; set; }
        public HashSet<Course>RegistredCourses {get; set;}
        #endregion
        #region method
       

       
        #endregion
    }
}
