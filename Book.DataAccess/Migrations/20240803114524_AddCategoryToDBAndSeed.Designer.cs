﻿// <auto-generated />
using Book.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Book.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240803114524_AddCategoryToDBAndSeed")]
    partial class AddCategoryToDBAndSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Book.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 20,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 15,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 33,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 45,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 5,
                            DisplayOrder = 27,
                            Name = "Educational"
                        },
                        new
                        {
                            Id = 6,
                            DisplayOrder = 16,
                            Name = "Self-help"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}