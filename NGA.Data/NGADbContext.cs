using Microsoft.EntityFrameworkCore;
using NGA.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGA.Data
{
    public class NGADbContext : DbContext
    {
        public NGADbContext(DbContextOptions<NGADbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
