﻿// <auto-generated />
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
    [Migration("20230823212859_setDefaultInvQty")]
    partial class setDefaultInvQty
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LivexDevTechnicalAssessment.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");
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

                    b.HasKey("Id");

                    b.ToTable("InventoryItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Marvel Comic",
                            Price = 149.99000000000001,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bible",
                            Price = 89.989999999999995,
                            Quantity = 5
                        },
                        new
                        {
                            Id = 3,
                            Name = "One Piece",
                            Price = 49.990000000000002,
                            Quantity = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}