﻿// <auto-generated />
using DateMe.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DateMe.Migrations
{
    [DbContext(typeof(DatingApplicationContext))]
    [Migration("20240220195831_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("DateMe.Models.Application", b =>
                {
                    b.Property<int>("ApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CreeperStalker")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MajorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ApplicationID");

                    b.HasIndex("MajorId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("DateMe.Models.Major", b =>
                {
                    b.Property<int>("MajorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MajorName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MajorId");

                    b.ToTable("Majors");

                    b.HasData(
                        new
                        {
                            MajorId = 1,
                            MajorName = "Information Systems"
                        },
                        new
                        {
                            MajorId = 2,
                            MajorName = "Computer Science"
                        },
                        new
                        {
                            MajorId = 3,
                            MajorName = "Magic"
                        },
                        new
                        {
                            MajorId = 4,
                            MajorName = "Banana Stand"
                        },
                        new
                        {
                            MajorId = 5,
                            MajorName = "Business Administration"
                        });
                });

            modelBuilder.Entity("DateMe.Models.Application", b =>
                {
                    b.HasOne("DateMe.Models.Major", "Major")
                        .WithMany()
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Major");
                });
#pragma warning restore 612, 618
        }
    }
}
