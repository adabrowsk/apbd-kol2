﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kol2.Data;

#nullable disable

namespace kol2.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("kol2.Models.Backpack", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("ItemId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("Backpack");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            CharacterId = 1,
                            Amount = 2
                        });
                });

            modelBuilder.Entity("kol2.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrentWeight")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("MaxWeight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrentWeight = 2,
                            FirstName = "name",
                            LastName = "lastname",
                            MaxWeight = 10
                        });
                });

            modelBuilder.Entity("kol2.Models.CharacterTitle", b =>
                {
                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AcquiredAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TitleId1")
                        .HasColumnType("int");

                    b.HasKey("TitleId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.HasIndex("TitleId1");

                    b.ToTable("CharacterTitle");

                    b.HasData(
                        new
                        {
                            TitleId = 1,
                            CharacterId = 1,
                            AcquiredAt = new DateTime(2024, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("kol2.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "item",
                            Weight = 2
                        });
                });

            modelBuilder.Entity("kol2.Models.Title", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Titles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "title"
                        });
                });

            modelBuilder.Entity("kol2.Models.Backpack", b =>
                {
                    b.HasOne("kol2.Models.Character", "Character")
                        .WithMany("Backpacks")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("kol2.Models.Item", "Item")
                        .WithMany("Backpacks")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("kol2.Models.CharacterTitle", b =>
                {
                    b.HasOne("kol2.Models.Character", "Character")
                        .WithMany("CharacterTitles")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("kol2.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("kol2.Models.Title", null)
                        .WithMany("CharacterTitles")
                        .HasForeignKey("TitleId1");

                    b.Navigation("Character");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("kol2.Models.Character", b =>
                {
                    b.Navigation("Backpacks");

                    b.Navigation("CharacterTitles");
                });

            modelBuilder.Entity("kol2.Models.Item", b =>
                {
                    b.Navigation("Backpacks");
                });

            modelBuilder.Entity("kol2.Models.Title", b =>
                {
                    b.Navigation("CharacterTitles");
                });
#pragma warning restore 612, 618
        }
    }
}
