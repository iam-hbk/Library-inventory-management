﻿// <auto-generated />
using System;
using LivexDevTechnicalAssessment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LivexDevTechnicalAssessment.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230824215412_addedInventoryItemTypeDefault1")]
    partial class addedInventoryItemTypeDefault1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LivexDevTechnicalAssessment.Models.Checkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CheckoutDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int>("InventoryItemId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("InventoryItemId");

                    b.ToTable("Checkouts");
                });

            modelBuilder.Entity("LivexDevTechnicalAssessment.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Email = "heritier@gmail.com",
                            Name = "Heritier"
                        },
                        new
                        {
                            Id = 1,
                            Email = "Rione@livex.co.za",
                            Name = "Rione"
                        });
                });

            modelBuilder.Entity("LivexDevTechnicalAssessment.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<int>("type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("InventoryItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Marvel Comic",
                            Price = 149.99000000000001,
                            Quantity = 10,
                            type = 0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bible",
                            Price = 89.989999999999995,
                            Quantity = 5,
                            type = 0
                        },
                        new
                        {
                            Id = 3,
                            Name = "One Piece",
                            Price = 49.990000000000002,
                            Quantity = 2,
                            type = 0
                        });
                });

            modelBuilder.Entity("LivexDevTechnicalAssessment.Models.Checkout", b =>
                {
                    b.HasOne("LivexDevTechnicalAssessment.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LivexDevTechnicalAssessment.Models.Inventory", "InventoryItem")
                        .WithMany()
                        .HasForeignKey("InventoryItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("InventoryItem");
                });
#pragma warning restore 612, 618
        }
    }
}
