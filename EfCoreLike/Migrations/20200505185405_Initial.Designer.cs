﻿// <auto-generated />
using System;
using EfCoreLike;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfCoreLike.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200505185405_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfCoreLike.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address1 = "Gatan 5",
                            BirthDate = new DateTime(1975, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Uppsala",
                            Country = "Sverige",
                            FirstName = "Lisa",
                            JoinDate = new DateTime(2014, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Johansson",
                            PostCode = "75455"
                        },
                        new
                        {
                            Id = 2,
                            Address1 = "Vägen 55",
                            BirthDate = new DateTime(1992, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Uppsala",
                            Country = "Sverige",
                            FirstName = "Oscar",
                            JoinDate = new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Bengtsson",
                            PostCode = "75450"
                        },
                        new
                        {
                            Id = 3,
                            Address1 = "Långgatan 9",
                            BirthDate = new DateTime(2002, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Stockholm",
                            Country = "Sverige",
                            FirstName = "Fia",
                            JoinDate = new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Sten",
                            PostCode = "11011"
                        },
                        new
                        {
                            Id = 4,
                            Address1 = "Stora vägen 42",
                            BirthDate = new DateTime(1984, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Umeå",
                            Country = "Sverige",
                            FirstName = "Kalle",
                            JoinDate = new DateTime(2010, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Berg",
                            PostCode = "95433"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}