using System;
using System.Collections.Generic;
using System.Text;

namespace EnrollmentApp
{/// <summary>
/// This class is about a course for which students will registred.
/// </summary>
    class Course
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public float FeeAmount { get; set; }
        public int CreditHour { get; set; }
        public semisterNames semisterName { get; set; }
        public SemisterYear Semisterbatch { get; set; }




    }
}
