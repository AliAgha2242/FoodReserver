﻿// <auto-generated />
using System;
using Infrastructure.Database.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    [DbContext(typeof(ReserveFoodDb))]
    partial class ReserveFoodDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DaysOfWeekForWorkEmployer", b =>
                {
                    b.Property<Guid>("DaysOfWeeksForWorkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("employersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DaysOfWeeksForWorkId", "employersId");

                    b.HasIndex("employersId");

                    b.ToTable("DaysOfWeekForWorkEmployer");
                });

            modelBuilder.Entity("Domain.Entities.AddressAggreagte.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsUnBlock")
                        .HasColumnType("bit");

                    b.Property<string>("Ostan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pelak")
                        .HasColumnType("int");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<string>("RestAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shahr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Domain.Entities.FoodAggregate.Food", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FoodCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Prise")
                        .HasColumnType("int");

                    b.Property<byte>("SuitableHowMany")
                        .HasColumnType("tinyint");

                    b.Property<long>("Weight")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FoodCategoryId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("Domain.Entities.FoodAggregate.FoodFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Alt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FoodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Size")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FoodId")
                        .IsUnique();

                    b.ToTable("FoodFile");
                });

            modelBuilder.Entity("Domain.Entities.FoodCategoryAggregate.FoodCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ParentCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("FoodCategories");
                });

            modelBuilder.Entity("Domain.Entities.OperatoreAggregate.DaysOfWeekForWork", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("DaysOfWeekForWork");
                });

            modelBuilder.Entity("Domain.Entities.OperatoreAggregate.Employer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmployerCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("EmploymentDate")
                        .HasColumnType("date");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("HourseOfWorkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<byte>("TimeOfContract")
                        .HasColumnType("tinyint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HourseOfWorkId");

                    b.ToTable("Employers");
                });

            modelBuilder.Entity("Domain.Entities.OperatoreAggregate.HourseOfWork", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeOnly>("EndWork")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("StartWork")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("HourseOfWork");
                });

            modelBuilder.Entity("Domain.Entities.PersonAggregate.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Domain.Entities.ReciveAggregate.Recive", b =>
                {
                    b.Property<Guid>("ReserveId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EmployerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PayType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReciveDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ReserveId");

                    b.HasIndex("EmployerId");

                    b.ToTable("Recives");
                });

            modelBuilder.Entity("Domain.Entities.ReserveAggregate.Reserve", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Addressid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateReserveTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReserveDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Addressid");

                    b.HasIndex("PersonId");

                    b.ToTable("Reserves");
                });

            modelBuilder.Entity("FoodReserve", b =>
                {
                    b.Property<Guid>("FoodsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReservesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FoodsId", "ReservesId");

                    b.HasIndex("ReservesId");

                    b.ToTable("FoodReserve");
                });

            modelBuilder.Entity("DaysOfWeekForWorkEmployer", b =>
                {
                    b.HasOne("Domain.Entities.OperatoreAggregate.DaysOfWeekForWork", null)
                        .WithMany()
                        .HasForeignKey("DaysOfWeeksForWorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.OperatoreAggregate.Employer", null)
                        .WithMany()
                        .HasForeignKey("employersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.AddressAggreagte.Address", b =>
                {
                    b.HasOne("Domain.Entities.PersonAggregate.Person", "Person")
                        .WithMany("Addresses")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Domain.Entities.FoodAggregate.Food", b =>
                {
                    b.HasOne("Domain.Entities.FoodCategoryAggregate.FoodCategory", "FoodCategory")
                        .WithMany("Foods")
                        .HasForeignKey("FoodCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodCategory");
                });

            modelBuilder.Entity("Domain.Entities.FoodAggregate.FoodFile", b =>
                {
                    b.HasOne("Domain.Entities.FoodAggregate.Food", "Food")
                        .WithOne("FoodFile")
                        .HasForeignKey("Domain.Entities.FoodAggregate.FoodFile", "FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");
                });

            modelBuilder.Entity("Domain.Entities.FoodCategoryAggregate.FoodCategory", b =>
                {
                    b.HasOne("Domain.Entities.FoodCategoryAggregate.FoodCategory", "ParentCategory")
                        .WithMany("SubCategory")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Domain.Entities.OperatoreAggregate.Employer", b =>
                {
                    b.HasOne("Domain.Entities.OperatoreAggregate.HourseOfWork", "HourseOfWork")
                        .WithMany("Employers")
                        .HasForeignKey("HourseOfWorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HourseOfWork");
                });

            modelBuilder.Entity("Domain.Entities.ReciveAggregate.Recive", b =>
                {
                    b.HasOne("Domain.Entities.OperatoreAggregate.Employer", "Employer")
                        .WithMany("Recives")
                        .HasForeignKey("EmployerId");

                    b.HasOne("Domain.Entities.ReserveAggregate.Reserve", "Reserve")
                        .WithOne("Recive")
                        .HasForeignKey("Domain.Entities.ReciveAggregate.Recive", "ReserveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employer");

                    b.Navigation("Reserve");
                });

            modelBuilder.Entity("Domain.Entities.ReserveAggregate.Reserve", b =>
                {
                    b.HasOne("Domain.Entities.AddressAggreagte.Address", "Address")
                        .WithMany("Reserves")
                        .HasForeignKey("Addressid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.PersonAggregate.Person", "Person")
                        .WithMany("Reserves")
                        .HasForeignKey("PersonId");

                    b.Navigation("Address");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("FoodReserve", b =>
                {
                    b.HasOne("Domain.Entities.FoodAggregate.Food", null)
                        .WithMany()
                        .HasForeignKey("FoodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ReserveAggregate.Reserve", null)
                        .WithMany()
                        .HasForeignKey("ReservesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.AddressAggreagte.Address", b =>
                {
                    b.Navigation("Reserves");
                });

            modelBuilder.Entity("Domain.Entities.FoodAggregate.Food", b =>
                {
                    b.Navigation("FoodFile")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.FoodCategoryAggregate.FoodCategory", b =>
                {
                    b.Navigation("Foods");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Domain.Entities.OperatoreAggregate.Employer", b =>
                {
                    b.Navigation("Recives");
                });

            modelBuilder.Entity("Domain.Entities.OperatoreAggregate.HourseOfWork", b =>
                {
                    b.Navigation("Employers");
                });

            modelBuilder.Entity("Domain.Entities.PersonAggregate.Person", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Reserves");
                });

            modelBuilder.Entity("Domain.Entities.ReserveAggregate.Reserve", b =>
                {
                    b.Navigation("Recive");
                });
#pragma warning restore 612, 618
        }
    }
}
