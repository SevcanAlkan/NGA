using NGA.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGA.Domain
{
    public class Course : Table
    {    
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
