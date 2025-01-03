﻿// <auto-generated />
using System;
using Managing_Movie_Collection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Managing_Movie_Collection.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241124100559_data")]
    partial class data
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DirectorMovie", b =>
                {
                    b.Property<int>("DirectorsId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("DirectorsId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("DirectorMovie");
                });

            modelBuilder.Entity("Managing_Movie_Collection.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Managing_Movie_Collection.Models.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Placehorder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("Managing_Movie_Collection.Models.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NatinalityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NatinalityId")
                        .IsUnique()
                        .HasFilter("[NatinalityId] IS NOT NULL");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("Managing_Movie_Collection.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CienemaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleseYear")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CienemaId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Managing_Movie_Collection.Models.Nationality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Nationalities");
                });

            modelBuilder.Entity("DirectorMovie", b =>
                {
                    b.HasOne("Managing_Movie_Collection.Models.Director", null)
                        .WithMany()
                        .HasForeignKey("DirectorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Managing_Movie_Collection.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Managing_Movie_Collection.Models.Director", b =>
                {
                    b.HasOne("Managing_Movie_Collection.Models.Nationality", "Nationality")
                        .WithOne("Director")
                        .HasForeignKey("Managing_Movie_Collection.Models.Director", "NatinalityId");

                    b.Navigation("Nationality");
                });

            modelBuilder.Entity("Managing_Movie_Collection.Models.Movie", b =>
                {
                    b.HasOne("Managing_Movie_Collection.Models.Category", "Category")
                        .WithMany("Movies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Managing_Movie_Collection.Models.Cinema", "Cinema")
                        .WithMany("Movies")
                        .HasForeignKey("CienemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("Managing_Movie_Collection.Models.Category", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Managing_Movie_Collection.Models.Cinema", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Managing_Movie_Collection.Models.Nationality", b =>
                {
                    b.Navigation("Director")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
