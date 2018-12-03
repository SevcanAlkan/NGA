using NGA.Core.EntityFramework;
using NGA.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGA.Domain
{
    public class Enrollment : Table
    {
        public Guid CourseID { get; set; }
        public Guid StudentID { get; set; }
        public Grade? Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
