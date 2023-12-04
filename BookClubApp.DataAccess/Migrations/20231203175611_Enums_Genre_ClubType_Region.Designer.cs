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
    [Migration("20231203175611_Enums_Genre_ClubType_Region")]
    partial class Enums_Genre_ClubType_Region
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

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pages")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublicationYear")
                        .HasColumnType("int");

                    b.Property<string>("Publisher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description of Book 1",
                            ISBN = "978-3-16-148410-0",
                            Identifier = "A123",
                            Language = "English",
                            Pages = "300",
                            PublicationYear = 2020,
                            Publisher = "Publisher 1",
                            Title = "Sample Book 1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Description of Book 2",
                            ISBN = "978-1-23-456789-7",
                            Identifier = "B456",
                            Language = "Spanish",
                            Pages = "250",
                            PublicationYear = 2021,
                            Publisher = "Publisher 2",
                            Title = "Sample Book 2"
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("BookClubs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description of Book Club 1",
                            Genre = "Fiction",
                            Name = "Book Club 1",
                            Region = "NorthAmerica",
                            Type = "Online"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Description of Book Club 2",
                            Genre = "NonFiction",
                            Name = "Book Club 2",
                            Region = "Europe",
                            Type = "Local"
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

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.Rating", b =>
                {
                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
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
                            Id = 1,
                            Score = 5
                        },
                        new
                        {
                            MemberId = 1,
                            BookId = 2,
                            Id = 2,
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

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.Membership", b =>
                {
                    b.HasOne("BookClubApp.DataAccess.Entities.BookClub", "BookClub")
                        .WithMany()
                        .HasForeignKey("BookClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookClubApp.DataAccess.Entities.Member", "Member")
                        .WithMany("Memberships")
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

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.Member", b =>
                {
                    b.Navigation("Memberships");
                });

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.Role", b =>
                {
                    b.Navigation("Memberships");
                });
#pragma warning restore 612, 618
        }
    }
}
