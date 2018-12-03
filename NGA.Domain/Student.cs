using NGA.Core.EntityFramework;
using System;
using System.Collections.Generic;

namespace NGA.Domain
{
    public class Student : Table
    {
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
