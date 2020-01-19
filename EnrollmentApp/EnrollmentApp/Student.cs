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
        #region Properties
        public Student()
        {
            Id=++LastRegistredStudentId;
        }
        public int Id { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay{ get; set; }
        public DateTime DateOfRegistration { get; set; }
        public char Sex{ get; set; }
        #endregion



    }
}
