﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Services.PlayerRating.Models.DAL;

#nullable disable

namespace Services.PlayerRating.Migrations
{
    [DbContext(typeof(PgContext))]
    partial class PgContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Services.PlayerRating.DAL.Interfaces.Entity.Games", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Services.PlayerRating.DAL.Interfaces.Entity.Players", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Services.PlayerRating.DAL.Interfaces.Entity.Scores", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("GameID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlayerID")
                        .HasColumnType("uuid");

                    b.Property<long>("Score")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.HasIndex("PlayerID");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("Services.PlayerRating.DAL.Interfaces.Entity.Scores", b =>
                {
                    b.HasOne("Services.PlayerRating.DAL.Interfaces.Entity.Games", "Game")
                        .WithMany()
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Services.PlayerRating.DAL.Interfaces.Entity.Players", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });
#pragma warning restore 612, 618
        }
    }
}
