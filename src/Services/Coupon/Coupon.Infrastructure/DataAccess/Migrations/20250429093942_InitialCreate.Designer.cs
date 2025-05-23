﻿// <auto-generated />
using System;
using Coupon.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Coupon.Infrastructure.DataAccess.Migrations
{
    [DbContext(typeof(CouponDbContext))]
    [Migration("20250429093942_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Coupon.Domain.Entities.CouponDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Coupons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("71944ed3-fee6-4320-a6e1-de4910eb9d26"),
                            Amount = 10,
                            Description = "Description 1",
                            ProductName = "Product 1"
                        },
                        new
                        {
                            Id = new Guid("e3c826f0-9228-4a05-856e-6a94d3af29cb"),
                            Amount = 20,
                            Description = "Description 2",
                            ProductName = "Product 2"
                        },
                        new
                        {
                            Id = new Guid("cf006002-9ed4-48a8-ada9-ad6381e8df1f"),
                            Amount = 30,
                            Description = "Description 3",
                            ProductName = "Product 3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
