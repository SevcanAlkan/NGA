﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NGA.Data;

namespace NGA.Data.Migrations
{
    [DbContext(typeof(NGADbContext))]
    [Migration("20181205133633_B1-M1")]
    partial class B1M1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NGA.Domain.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("CreateDT");

                    b.Property<int>("Credits");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Title");

                    b.Property<Guid?>("UpdateBy");

                    b.Property<DateTime?>("UpdateDT");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("NGA.Domain.Enrollment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CourseID");

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("CreateDT");

                    b.Property<int?>("Grade");

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid>("StudentID");

                    b.Property<Guid?>("UpdateBy");

                    b.Property<DateTime?>("UpdateDT");

                    b.HasKey("Id");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("NGA.Domain.Parameter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("CreateDT");

                    b.Property<string>("GroupCode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("OrderIndex");

                    b.Property<Guid?>("UpdateBy");

                    b.Property<DateTime?>("UpdateDT");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Parameter");
                });

            modelBuilder.Entity("NGA.Domain.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("CreateDT");

                    b.Property<DateTime>("EnrollmentDate");

                    b.Property<string>("FirstMidName");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.Property<Guid?>("UpdateBy");

                    b.Property<DateTime?>("UpdateDT");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("NGA.Domain.Enrollment", b =>
                {
                    b.HasOne("NGA.Domain.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NGA.Domain.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}