﻿// <auto-generated />
using System;
using Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Base.Entities.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20220310084821_UpdateUserTable")]
    partial class UpdateUserTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Base.Entities.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_user");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = 0,
                            DateCreated = new DateTime(2022, 3, 10, 16, 48, 20, 188, DateTimeKind.Local).AddTicks(8439),
                            DateModified = new DateTime(2022, 3, 10, 16, 48, 20, 188, DateTimeKind.Local).AddTicks(8448),
                            FirstName = "Role",
                            IsActive = true,
                            IsDeleted = false,
                            LastName = "Admin",
                            Password = "admin",
                            UpdatedBy = 0,
                            Username = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
