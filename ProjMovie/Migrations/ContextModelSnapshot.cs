﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjMovie.Models;

namespace ProjMovie.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ProjMovie.Models.MovieDb", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("MovieDbMovieId")
                        .HasColumnType("int");

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.HasIndex("MovieDbMovieId");

                    b.ToTable("MovieDbs");
                });

            modelBuilder.Entity("ProjMovie.Models.ReviewDb", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("MovieDbMovieId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReviewId");

                    b.HasIndex("MovieDbMovieId");

                    b.ToTable("ReviewDbs");
                });

            modelBuilder.Entity("ProjMovie.Models.MovieDb", b =>
                {
                    b.HasOne("ProjMovie.Models.MovieDb", null)
                        .WithMany("Moviedb")
                        .HasForeignKey("MovieDbMovieId");
                });

            modelBuilder.Entity("ProjMovie.Models.ReviewDb", b =>
                {
                    b.HasOne("ProjMovie.Models.MovieDb", "MovieDb")
                        .WithMany()
                        .HasForeignKey("MovieDbMovieId");

                    b.Navigation("MovieDb");
                });

            modelBuilder.Entity("ProjMovie.Models.MovieDb", b =>
                {
                    b.Navigation("Moviedb");
                });
#pragma warning restore 612, 618
        }
    }
}
