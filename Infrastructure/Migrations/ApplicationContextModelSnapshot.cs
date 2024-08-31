﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("Domain.Entities.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Directors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Chad Stahelski"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tim Miller"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Jon Watts"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Juan José Campanella"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Damián Szifron"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Fabián Bielinsky"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DirectorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsNational")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Un asesino a sueldo sale de su retiro para vengarse de los que le hicieron daño.",
                            DirectorId = 1,
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTrlMhuTYAKZHxZXA4OzjqcKaopJEjTOzLxnQ&s",
                            IsNational = false,
                            Title = "John Wick"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Un mercenario con habilidades de curación acelerada busca venganza.",
                            DirectorId = 2,
                            ImageUrl = "https://pics.filmaffinity.com/Deadpool-834516798-mmed.jpg",
                            IsNational = false,
                            Title = "Deadpool"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Un joven adquiere habilidades arácnidas después de ser mordido por una araña radioactiva.",
                            DirectorId = 3,
                            ImageUrl = "https://hips.hearstapps.com/hmg-prod/images/spiderman-homecoming-poster-1551691492.jpg",
                            IsNational = false,
                            Title = "Spiderman"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Un ex funcionario judicial decide escribir una novela basada en un caso real que lo afectó profundamente.",
                            DirectorId = 4,
                            ImageUrl = "https://m.media-amazon.com/images/I/61dlTXqaMLL._AC_SL1024_.jpg",
                            IsNational = true,
                            Title = "El secreto de sus ojos"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Una serie de seis cortometrajes que exploran la violencia y la venganza en diferentes formas.",
                            DirectorId = 5,
                            ImageUrl = "https://pics.filmaffinity.com/relatos_salvajes-285164385-large.jpg",
                            IsNational = true,
                            Title = "Relatos salvajes"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Dos estafadores intentan vender una serie de sellos falsos extremadamente valiosos.",
                            DirectorId = 6,
                            ImageUrl = "https://m.media-amazon.com/images/I/71aA-cKYcWL._AC_SL1500_.jpg",
                            IsNational = true,
                            Title = "Nueve reinas"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Show", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("Domain.Entities.Movie", b =>
                {
                    b.HasOne("Domain.Entities.Director", null)
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Show", b =>
                {
                    b.HasOne("Domain.Entities.Movie", "Movie")
                        .WithMany("Shows")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Domain.Entities.Director", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Domain.Entities.Movie", b =>
                {
                    b.Navigation("Shows");
                });
#pragma warning restore 612, 618
        }
    }
}
