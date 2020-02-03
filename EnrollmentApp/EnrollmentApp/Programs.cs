using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnrollmentApp
{
    /// <summary>
    /// This class is about a stream in which students will be enrolled.
    /// </summary>
    class Programs
    {
        public programsNames ProgramName { get; set; }
        public IEnumerable<Course>Courses {get; set;}
        public List<Student> RegisredStudentsList { get; set; }

        public IEnumerable<Course>DisplayCoursesForYearPerSemister(semisterNames semister,SemisterYear year)
        {
            return Courses.Where(c => c.semisterName == semister && c.Semisterbatch == year);

                
        }
    }
}
