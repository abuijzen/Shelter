﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shelter.shared;

namespace Shelter.mvc.Migrations
{
    [DbContext(typeof(ShelterContext))]
    [Migration("20200110214119_SeedShelters")]
    partial class SeedShelters
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Shelter.shared.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Allergies")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Bio")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsAnimalFriendly")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsFertile")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsKidFriendly")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsSpeciesFriendly")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Race")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ShelterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Since")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ShelterId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Shelter.shared.Employees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Employees");
                });

            modelBuilder.Entity("Shelter.shared.Shelter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("EmailAdress")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Shelters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Kievitstraat 40",
                            EmailAdress = "/",
                            ImageUrl = "canina",
                            Name = "Canina",
                            TelephoneNumber = "036771291"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Toekomststraat 4",
                            EmailAdress = "veeweyde.weelde@skynet.be",
                            ImageUrl = "image",
                            Name = "Veeweyde vzw",
                            TelephoneNumber = "014658626"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Houwaartstraat 15, 3210 Lubbeek",
                            EmailAdress = "info@kat-lijn.be",
                            ImageUrl = "https://www.dierendonatie.be/wp-content/uploads/2019/01/29570550_2080399628857532_4696137069563272630_n.jpg",
                            Name = "kat-lijn vzw",
                            TelephoneNumber = "0468 56 93 72"
                        });
                });

            modelBuilder.Entity("Shelter.shared.Administrator", b =>
                {
                    b.HasBaseType("Shelter.shared.Employees");

                    b.Property<int?>("ShelterId")
                        .HasColumnType("int");

                    b.HasIndex("ShelterId");

                    b.HasDiscriminator().HasValue("Administrator");
                });

            modelBuilder.Entity("Shelter.shared.Caretaker", b =>
                {
                    b.HasBaseType("Shelter.shared.Employees");

                    b.Property<int?>("ShelterId")
                        .HasColumnName("Caretaker_ShelterId")
                        .HasColumnType("int");

                    b.HasIndex("ShelterId");

                    b.HasDiscriminator().HasValue("Caretaker");
                });

            modelBuilder.Entity("Shelter.shared.Manager", b =>
                {
                    b.HasBaseType("Shelter.shared.Employees");

                    b.Property<int?>("ShelterId")
                        .HasColumnName("Manager_ShelterId")
                        .HasColumnType("int");

                    b.HasIndex("ShelterId");

                    b.HasDiscriminator().HasValue("Manager");
                });

            modelBuilder.Entity("Shelter.shared.Animal", b =>
                {
                    b.HasOne("Shelter.shared.Shelter", null)
                        .WithMany("Animals")
                        .HasForeignKey("ShelterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shelter.shared.Administrator", b =>
                {
                    b.HasOne("Shelter.shared.Shelter", null)
                        .WithMany("Administrators")
                        .HasForeignKey("ShelterId");
                });

            modelBuilder.Entity("Shelter.shared.Caretaker", b =>
                {
                    b.HasOne("Shelter.shared.Shelter", null)
                        .WithMany("Caretakers")
                        .HasForeignKey("ShelterId");
                });

            modelBuilder.Entity("Shelter.shared.Manager", b =>
                {
                    b.HasOne("Shelter.shared.Shelter", null)
                        .WithMany("Managers")
                        .HasForeignKey("ShelterId");
                });
#pragma warning restore 612, 618
        }
    }
}
