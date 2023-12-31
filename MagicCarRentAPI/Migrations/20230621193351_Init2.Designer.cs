﻿// <auto-generated />
using System;
using MagicCarRentAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicCarRentAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230621193351_Init2")]
    partial class Init2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicCarRentAPI.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CarColor")
                        .HasColumnType("int");

                    b.Property<double>("CostDay")
                        .HasColumnType("float");

                    b.Property<double>("CostHour")
                        .HasColumnType("float");

                    b.Property<bool>("IsInService")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRentedNow")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalMoneyEarn")
                        .HasColumnType("float");

                    b.Property<double>("TotalRentTime")
                        .HasColumnType("float");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Toyota",
                            CarColor = 0,
                            CostDay = 2000.0,
                            CostHour = 350.0,
                            IsInService = false,
                            IsRentedNow = false,
                            Model = "Mark II",
                            TotalMoneyEarn = 0.0,
                            TotalRentTime = 0.0,
                            Year = 1995
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Honda",
                            CarColor = 1,
                            CostDay = 2200.0,
                            CostHour = 400.0,
                            IsInService = false,
                            IsRentedNow = false,
                            Model = "Civic",
                            TotalMoneyEarn = 0.0,
                            TotalRentTime = 0.0,
                            Year = 2010
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Ford",
                            CarColor = 2,
                            CostDay = 5000.0,
                            CostHour = 800.0,
                            IsInService = false,
                            IsRentedNow = false,
                            Model = "Mustang",
                            TotalMoneyEarn = 0.0,
                            TotalRentTime = 0.0,
                            Year = 2015
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Chevrolet",
                            CarColor = 3,
                            CostDay = 7000.0,
                            CostHour = 1000.0,
                            IsInService = false,
                            IsRentedNow = false,
                            Model = "Camaro",
                            TotalMoneyEarn = 0.0,
                            TotalRentTime = 0.0,
                            Year = 2018
                        },
                        new
                        {
                            Id = 5,
                            Brand = "BMW",
                            CarColor = 4,
                            CostDay = 6000.0,
                            CostHour = 900.0,
                            IsInService = false,
                            IsRentedNow = false,
                            Model = "M5",
                            TotalMoneyEarn = 0.0,
                            TotalRentTime = 0.0,
                            Year = 2020
                        });
                });

            modelBuilder.Entity("MagicCarRentAPI.Entities.CarClientJournal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("BeginRent")
                        .HasColumnType("datetime2");

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<int?>("DiscountId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndRent")
                        .HasColumnType("datetime2");

                    b.Property<double>("RentBill")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CarID");

                    b.HasIndex("ClientID");

                    b.HasIndex("DiscountId");

                    b.ToTable("ClientJournals");
                });

            modelBuilder.Entity("MagicCarRentAPI.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Experience")
                        .HasColumnType("float");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.Property<double>("TotalBill")
                        .HasColumnType("float");

                    b.Property<double>("TotalDebt")
                        .HasColumnType("float");

                    b.Property<double>("TotalDrivingTime")
                        .HasColumnType("float");

                    b.Property<double>("TotalPay")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Experience = 0.0,
                            Lastname = "Doe",
                            Name = "John",
                            Score = 0.0,
                            TotalBill = 0.0,
                            TotalDebt = 0.0,
                            TotalDrivingTime = 0.0,
                            TotalPay = 0.0
                        },
                        new
                        {
                            Id = 2,
                            Experience = 0.0,
                            Lastname = "Smith",
                            Name = "Alice",
                            Score = 0.0,
                            TotalBill = 0.0,
                            TotalDebt = 0.0,
                            TotalDrivingTime = 0.0,
                            TotalPay = 0.0
                        },
                        new
                        {
                            Id = 3,
                            Experience = 0.0,
                            Lastname = "Johnson",
                            Name = "Michael",
                            Score = 0.0,
                            TotalBill = 0.0,
                            TotalDebt = 0.0,
                            TotalDrivingTime = 0.0,
                            TotalPay = 0.0
                        },
                        new
                        {
                            Id = 4,
                            Experience = 0.0,
                            Lastname = "Brown",
                            Name = "Emily",
                            Score = 0.0,
                            TotalBill = 0.0,
                            TotalDebt = 0.0,
                            TotalDrivingTime = 0.0,
                            TotalPay = 0.0
                        },
                        new
                        {
                            Id = 5,
                            Experience = 0.0,
                            Lastname = "Wilson",
                            Name = "David",
                            Score = 0.0,
                            TotalBill = 0.0,
                            TotalDebt = 0.0,
                            TotalDrivingTime = 0.0,
                            TotalPay = 0.0
                        });
                });

            modelBuilder.Entity("MagicCarRentAPI.Entities.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DiscountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DiscountRate")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Discounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DiscountName = "Скидка 1-й уровень",
                            DiscountRate = 0.050000000000000003
                        },
                        new
                        {
                            Id = 2,
                            DiscountName = "Скидка 2-й уровень",
                            DiscountRate = 0.10000000000000001
                        },
                        new
                        {
                            Id = 3,
                            DiscountName = "Скидка 3-й уровень",
                            DiscountRate = 0.14999999999999999
                        },
                        new
                        {
                            Id = 4,
                            DiscountName = "Скидка 4-й уровень",
                            DiscountRate = 0.20000000000000001
                        },
                        new
                        {
                            Id = 5,
                            DiscountName = "Скидка 5-й уровень",
                            DiscountRate = 0.25
                        });
                });

            modelBuilder.Entity("MagicCarRentAPI.Entities.CarClientJournal", b =>
                {
                    b.HasOne("MagicCarRentAPI.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MagicCarRentAPI.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MagicCarRentAPI.Entities.Discount", "Discount")
                        .WithMany()
                        .HasForeignKey("DiscountId");

                    b.Navigation("Car");

                    b.Navigation("Client");

                    b.Navigation("Discount");
                });
#pragma warning restore 612, 618
        }
    }
}
