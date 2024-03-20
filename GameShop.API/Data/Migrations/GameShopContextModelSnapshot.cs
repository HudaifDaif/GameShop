﻿// <auto-generated />
using System;
using GameShop.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameShop.API.Data.Migrations
{
    [DbContext(typeof(GameShopContext))]
    partial class GameShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("GameShop.API.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameShop.API.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "RPG"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Strategy"
                        },
                        new
                        {
                            Id = 4,
                            Name = "First Person Shooter"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Mech"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Puzzle"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Racing"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Fighting"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Arcade"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Platformer"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 13,
                            Name = "MMO"
                        },
                        new
                        {
                            Id = 14,
                            Name = "RTS"
                        },
                        new
                        {
                            Id = 15,
                            Name = "CRPG"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 17,
                            Name = "MOBA"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Card Game"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Simulation"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Third Person Shooter"
                        });
                });

            modelBuilder.Entity("GameShop.API.Entities.Game", b =>
                {
                    b.HasOne("GameShop.API.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}