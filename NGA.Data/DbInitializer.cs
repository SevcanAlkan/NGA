using NGA.Core.Enum;
using NGA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NGA.Data
{
    public static class DbInitializer
    {
        public static void Initialize(NGADbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
            new Student{Id=new Guid(),FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{Id=new Guid(),FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{Id=new Guid(),FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{Id=new Guid(),FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{Id=new Guid(),FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{Id=new Guid(),FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{Id=new Guid(),FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{Id=new Guid(),FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
            new Course{Id=new Guid(),Title="Chemistry",Credits=3},
            new Course{Id=new Guid(),Title="Microeconomics",Credits=3},
            new Course{Id=new Guid(),Title="Macroeconomics",Credits=3},
            new Course{Id=new Guid(),Title="Calculus",Credits=4},
            new Course{Id=new Guid(),Title="Trigonometry",Credits=4},
            new Course{Id=new Guid(),Title="Composition",Credits=3},
            new Course{Id=new Guid(),Title="Literature",Credits=4}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
            new Enrollment{StudentID=students[1].Id,CourseID=courses[1].Id,Grade=Grade.A},
            new Enrollment{StudentID=students[2].Id,CourseID=courses[1].Id,Grade=Grade.C},
            new Enrollment{StudentID=students[3].Id,CourseID=courses[1].Id,Grade=Grade.B},
            new Enrollment{StudentID=students[4].Id,CourseID=courses[1].Id,Grade=Grade.B},
            new Enrollment{StudentID=students[5].Id,CourseID=courses[1].Id,Grade=Grade.F},
            new Enrollment{StudentID=students[7].Id,CourseID=courses[1].Id,Grade=Grade.F},
            new Enrollment{StudentID=students[1].Id,CourseID=courses[2].Id},
            new Enrollment{StudentID=students[2].Id,CourseID=courses[2].Id},
            new Enrollment{StudentID=students[3].Id,CourseID=courses[2].Id,Grade=Grade.F},
            new Enrollment{StudentID=students[4].Id,CourseID=courses[3].Id,Grade=Grade.C},
            new Enrollment{StudentID=students[5].Id,CourseID=courses[5].Id},
            new Enrollment{StudentID=students[6].Id,CourseID=courses[4].Id,Grade=Grade.A},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}
