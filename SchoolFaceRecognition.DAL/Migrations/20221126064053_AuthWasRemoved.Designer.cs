﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolFaceRecognition.DAL.AppDbContext;

#nullable disable

namespace SchoolFaceRecognition.DAL.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20221126064053_AuthWasRemoved")]
    partial class AuthWasRemoved
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SchoolFaceRecognition.Core.Entities.Continuity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Activity")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Participant")
                        .HasColumnName("ACTIVITY");

                    b.Property<string>("CreaterUser")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("CREATER_USER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATION_DATE");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("END_DATE");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED");

                    b.Property<string>("RemoverUser")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("REMOVER_USER");

                    b.Property<DateTime?>("RemovingDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("REMOVING_DATE");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("START_DATE");

                    b.Property<int?>("StudentId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("STUDENT_ID");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATE_DATE");

                    b.Property<string>("UpdaterUser")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("UPDATER_USER");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("CONTINUITIES", "SCHOOL");
                });

            modelBuilder.Entity("SchoolFaceRecognition.Core.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreaterUser")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("CREATER_USER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATION_DATE");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NAME");

                    b.Property<string>("RemoverUser")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("REMOVER_USER");

                    b.Property<DateTime?>("RemovingDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("REMOVING_DATE");

                    b.Property<int?>("SpecialityId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("SPECIALITY_ID");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATE_DATE");

                    b.Property<string>("UpdaterUser")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("UPDATER_USER");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("UK_GROUP_NAME");

                    b.HasIndex("SpecialityId");

                    b.ToTable("GROUPS", "SCHOOL");
                });

            modelBuilder.Entity("SchoolFaceRecognition.Core.Entities.Speciality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CODE");

                    b.Property<string>("CreaterUser")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("CREATER_USER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATION_DATE");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NAME");

                    b.Property<string>("RemoverUser")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("REMOVER_USER");

                    b.Property<DateTime?>("RemovingDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("REMOVING_DATE");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATE_DATE");

                    b.Property<string>("UpdaterUser")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("UPDATER_USER");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasDatabaseName("UK_SPECIALITY_CODE");

                    b.ToTable("SPECIALITIES", "SCHOOL");
                });

            modelBuilder.Entity("SchoolFaceRecognition.Core.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ADDRESS");

                    b.Property<string>("CreaterUser")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("CREATER_USER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATION_DATE");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FATHER_NAME");

                    b.Property<int?>("GroupId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("GROUP_ID");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NAME");

                    b.Property<string>("RemoverUser")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("REMOVER_USER");

                    b.Property<DateTime?>("RemovingDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("REMOVING_DATE");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("SURNAME");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATE_DATE");

                    b.Property<string>("UpdaterUser")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("UPDATER_USER");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("STUDENTS", "SCHOOL");
                });

            modelBuilder.Entity("SchoolFaceRecognition.Core.Entities.Continuity", b =>
                {
                    b.HasOne("SchoolFaceRecognition.Core.Entities.Student", "Student")
                        .WithMany("Continuities")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK_CONTINUITIES_STUDENT_ID");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolFaceRecognition.Core.Entities.Group", b =>
                {
                    b.HasOne("SchoolFaceRecognition.Core.Entities.Speciality", "Speciality")
                        .WithMany("Groups")
                        .HasForeignKey("SpecialityId")
                        .IsRequired()
                        .HasConstraintName("FK_GROUPS_SPECIALITY_ID");

                    b.Navigation("Speciality");
                });

            modelBuilder.Entity("SchoolFaceRecognition.Core.Entities.Student", b =>
                {
                    b.HasOne("SchoolFaceRecognition.Core.Entities.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .IsRequired()
                        .HasConstraintName("FK_STUDENTS_GROUP_ID");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("SchoolFaceRecognition.Core.Entities.Group", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolFaceRecognition.Core.Entities.Speciality", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("SchoolFaceRecognition.Core.Entities.Student", b =>
                {
                    b.Navigation("Continuities");
                });
#pragma warning restore 612, 618
        }
    }
}
