﻿// <auto-generated />
using System;
using CourseManager.DataBase.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CourseManager.DataBase.SqlServer.Migrations
{
    [DbContext(typeof(CourseManagerDbContext))]
    partial class CourseManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseManager.Models.Entities.Student", b =>
                {
                    b.Property<long>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Address2")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Address3")
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("dateTime");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Gender")
                        .HasColumnType("varchar(2)");

                    b.Property<string>("SurName")
                        .HasColumnType("varchar(50)");

                    b.HasKey("StudentId");

                    b.ToTable("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
