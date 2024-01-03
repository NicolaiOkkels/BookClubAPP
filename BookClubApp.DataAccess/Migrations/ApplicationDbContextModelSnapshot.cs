﻿// <auto-generated />
using System;
using BookClubApp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookClubApp.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("MemberId")
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

                    b.HasIndex("MemberId");

                    b.ToTable("BookClubs");
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

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.Poll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookClubId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookClubId");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.PollBook", b =>
                {
                    b.Property<int>("PollId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("PollId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("PollBook");
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
                });

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("PollId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("PollId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.BookClub", b =>
                {
                    b.HasOne("BookClubApp.DataAccess.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("BookClubApp.DataAccess.Entities.Libraries", "Libraries")
                        .WithMany()
                        .HasForeignKey("LibrariesId");

                    b.HasOne("BookClubApp.DataAccess.Entities.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");

                    b.Navigation("Book");

                    b.Navigation("Libraries");

                    b.Navigation("Member");
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
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookClub");

                    b.Navigation("Member");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.Poll", b =>
                {
                    b.HasOne("BookClubApp.DataAccess.Entities.BookClub", "BookClub")
                        .WithMany()
                        .HasForeignKey("BookClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookClub");
                });

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.PollBook", b =>
                {
                    b.HasOne("BookClubApp.DataAccess.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookClubApp.DataAccess.Entities.Poll", "Poll")
                        .WithMany("PollBooks")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Poll");
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

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.Vote", b =>
                {
                    b.HasOne("BookClubApp.DataAccess.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookClubApp.DataAccess.Entities.Poll", "Poll")
                        .WithMany()
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Poll");
                });

            modelBuilder.Entity("BookClubApp.DataAccess.Entities.Poll", b =>
                {
                    b.Navigation("PollBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
