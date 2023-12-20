﻿// <auto-generated />
using System;
using BookClubApp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookClubApp.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231219171833_Added_Foreignkey_to_Message_entity")]
    partial class Added_Foreignkey_to_Message_entity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaterialType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Joanne K. Rowling",
                            CoverImage = "https://moreinfo.addi.dk/2.11/more_info_get.php?lokalid=137198843&attachment_type=forside_stor&bibliotek=870970&source_id=870970&key=fb7fb908d05c9c08b16d",
                            MaterialType = "bøger",
                            Pid = "870970-basis:137198843",
                            Title = "Harry Potter og De Vises Sten"
                        });
                });

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.BookClub", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("bit");

                    b.Property<int?>("LibrariesId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("LibrariesId");

                    b.ToTable("BookClubs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description of Book Club 1",
                            Genre = "Fiction",
                            IsOpen = true,
                            LibrariesId = 1,
                            Name = "Book Club 1",
                            Type = "Online"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Description of Book Club 2",
                            Genre = "NonFiction",
                            IsOpen = false,
                            LibrariesId = 2,
                            Name = "Book Club 2",
                            Type = "Local"
                        });
                });

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.Libraries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LibrarieAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LibrarieCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LibrarieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LibrarieNumber")
                        .HasColumnType("int");

                    b.Property<int?>("LibrarieZipCode")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Libraries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "kb@kb.dk",
                            LibrarieAddress = "Christians Brygge 8",
                            LibrarieCity = "København K",
                            LibrarieName = "Poster vedr. sproglige minoriteter Det Kgl. Bibliotek",
                            LibrarieNumber = 700300,
                            LibrarieZipCode = 1219,
                            PhoneNumber = "33474747"
                        },
                        new
                        {
                            Id = 2,
                            Email = "dcb@dcbib.dk",
                            LibrarieAddress = "Norderstrasse 59, 24939 Flensburg",
                            LibrarieCity = "Padborg",
                            LibrarieName = "Dansk Centralbibliotek for Sydslesvig e.V.",
                            LibrarieNumber = 700400,
                            LibrarieZipCode = 6330,
                            PhoneNumber = "+4946186970"
                        });
                });

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "john.doe@example.com",
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1990, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jane.smith@example.com",
                            Name = "Jane Smith"
                        });
                });

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.Membership", b =>
                {
                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("BookClubId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("MemberId", "BookClubId", "RoleId");

                    b.HasIndex("BookClubId");

                    b.HasIndex("RoleId");

                    b.ToTable("Memberships");

                    b.HasData(
                        new
                        {
                            MemberId = 1,
                            BookClubId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            MemberId = 2,
                            BookClubId = 1,
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookClubId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookClubId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.Rating", b =>
                {
                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("MemberId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            MemberId = 1,
                            BookId = 1,
                            Score = 5
                        },
                        new
                        {
                            MemberId = 1,
                            BookId = 2,
                            Score = 4
                        });
                });

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Member"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Owner"
                        });
                });

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.BookClub", b =>
                {
                    b.HasOne("BookClubApp.DataAccess.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("BookClubApp.DataAccess.Entities.Libraries", "Libraries")
                        .WithMany()
                        .HasForeignKey("LibrariesId");

                    b.Navigation("Book");

                    b.Navigation("Libraries");
                });

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.Membership", b =>
                {
                    b.HasOne("BookClubApp.DataAccess.Entities.BookClub", "BookClub")
                        .WithMany()
                        .HasForeignKey("BookClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookClubApp.DataAccess.Entities.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookClubApp.DataAccess.Entities.Role", "Role")
                        .WithMany("Memberships")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookClub");

                    b.Navigation("Member");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.Message", b =>
                {
                    b.HasOne("BookClubApp.DataAccess.Entities.BookClub", "BookClub")
                        .WithMany()
                        .HasForeignKey("BookClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookClub");
                });

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.Rating", b =>
                {
                    b.HasOne("BookClubApp.DataAccess.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookClubApp.DataAccess.Entities.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.Role", b =>
                {
                    b.Navigation("Memberships");
                });
#pragma warning restore 612, 618
        }
    }
}
