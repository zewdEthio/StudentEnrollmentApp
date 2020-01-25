using System;
using System.Collections.Generic;
using System.Text;

namespace EnrollmentApp
{
    /// <summary>
    /// This is a facory class
    /// </summary>
    static class CollegeRegistrar
    {
        #region properties
        /// <summary>
        /// Contains registred list of students at the college.
        /// </summary>

        static public List<Student> RegisredStudentsList { get; set; }
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
        static public void RegisterStudent(string firstName, string lastName, DateTime birthDay, StudentType type, Gender sex)
        {
            RegisredStudentsList.Add(new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDay = birthDay,
                Type = type,
                Sex = sex,
            });
        }
        #endregion
    }
}
