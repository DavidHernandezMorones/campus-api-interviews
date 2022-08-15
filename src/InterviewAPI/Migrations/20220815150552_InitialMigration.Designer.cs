﻿// <auto-generated />
using System;
using InterviewAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InterviewAPI.Migrations
{
    [DbContext(typeof(InterviewContext))]
    [Migration("20220815150552_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InterviewAPI.Models.Interview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Appointment")
                        .HasColumnType("date");

                    b.Property<int?>("IntervieweeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IntervieweeId");

                    b.ToTable("Interviews");
                });

            modelBuilder.Entity("InterviewAPI.Models.Interviewee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Interviewees");
                });

            modelBuilder.Entity("InterviewAPI.Models.Interviewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Interviewers");
                });

            modelBuilder.Entity("InterviewInterviewer", b =>
                {
                    b.Property<int>("InterviewersId")
                        .HasColumnType("int");

                    b.Property<int>("InterviewsId")
                        .HasColumnType("int");

                    b.HasKey("InterviewersId", "InterviewsId");

                    b.HasIndex("InterviewsId");

                    b.ToTable("InterviewInterviewer");
                });

            modelBuilder.Entity("InterviewAPI.Models.Interview", b =>
                {
                    b.HasOne("InterviewAPI.Models.Interviewee", "Interviewee")
                        .WithMany("Interviews")
                        .HasForeignKey("IntervieweeId");

                    b.Navigation("Interviewee");
                });

            modelBuilder.Entity("InterviewInterviewer", b =>
                {
                    b.HasOne("InterviewAPI.Models.Interviewer", null)
                        .WithMany()
                        .HasForeignKey("InterviewersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InterviewAPI.Models.Interview", null)
                        .WithMany()
                        .HasForeignKey("InterviewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InterviewAPI.Models.Interviewee", b =>
                {
                    b.Navigation("Interviews");
                });
#pragma warning restore 612, 618
        }
    }
}