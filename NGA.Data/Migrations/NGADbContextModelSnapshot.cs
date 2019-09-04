﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NGA.Data;

namespace NGA.Data.Migrations
{
    [DbContext(typeof(NGADbContext))]
    partial class NGADbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NGA.Domain.Animal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BirthDate");

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("CreateDT");

                    b.Property<byte>("Gender")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue((byte)1);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("NickName")
                        .HasMaxLength(100);

                    b.Property<byte>("Status")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue((byte)1);

                    b.Property<Guid>("TypeId");

                    b.Property<Guid?>("UpdateBy");

                    b.Property<DateTime?>("UpdateDT");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("NGA.Domain.AnimalType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("CreateDT");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<Guid?>("ParentId");

                    b.Property<Guid?>("UpdateBy");

                    b.Property<DateTime?>("UpdateDT");

                    b.HasKey("Id");

                    b.ToTable("AnimalType");
                });

            modelBuilder.Entity("NGA.Domain.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActionName")
                        .HasMaxLength(50);

                    b.Property<string>("ControllerName")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<byte>("MethodType");

                    b.Property<string>("Path")
                        .HasMaxLength(250);

                    b.Property<string>("RequestBody");

                    b.Property<int>("ResponseTime");

                    b.Property<string>("ReturnTypeName")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("NGA.Domain.LogError", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("InnerException");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Message");

                    b.Property<int>("OrderNum");

                    b.Property<Guid>("RequestId");

                    b.Property<string>("Source");

                    b.Property<string>("StackTrace");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("LogErrors");
                });

            modelBuilder.Entity("NGA.Domain.Nest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("CreateDT");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastCheckDate");

                    b.Property<DateTime?>("LastRepaireDate");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<byte>("Status")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue((byte)1);

                    b.Property<Guid?>("UpdateBy");

                    b.Property<DateTime?>("UpdateDT");

                    b.Property<double>("XCordinate");

                    b.Property<double>("YCordinate");

                    b.HasKey("Id");

                    b.ToTable("Nest");
                });

            modelBuilder.Entity("NGA.Domain.NestAnimal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AnimalId");

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("CreateDT");

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid>("NestId");

                    b.Property<Guid?>("UpdateBy");

                    b.Property<DateTime?>("UpdateDT");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("NestId");

                    b.ToTable("NestAnimal");
                });

            modelBuilder.Entity("NGA.Domain.Parameter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .HasMaxLength(100);

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("CreateDT");

                    b.Property<string>("GroupCode")
                        .HasMaxLength(10);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<int>("OrderIndex")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<Guid?>("UpdateBy");

                    b.Property<DateTime?>("UpdateDT");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Parameter");
                });

            modelBuilder.Entity("NGA.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bio")
                        .HasMaxLength(250);

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("CreateDT");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<bool>("IsApproved")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<bool>("IsBanned")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastLoginDateTime");

                    b.Property<string>("PaswordHash")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte>("Role")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue((byte)1);

                    b.Property<Guid?>("UpdateBy");

                    b.Property<DateTime?>("UpdateDT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("NGA.Domain.Animal", b =>
                {
                    b.HasOne("NGA.Domain.AnimalType", "Type")
                        .WithMany("Animals")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NGA.Domain.LogError", b =>
                {
                    b.HasOne("NGA.Domain.Log", "Request")
                        .WithMany("Errors")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NGA.Domain.NestAnimal", b =>
                {
                    b.HasOne("NGA.Domain.Animal", "Animal")
                        .WithMany("NestAnimals")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NGA.Domain.Nest", "Nest")
                        .WithMany("NestAnimals")
                        .HasForeignKey("NestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
