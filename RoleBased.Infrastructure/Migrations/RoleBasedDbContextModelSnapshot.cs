﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RoleBased.Infrastructure.Persistence;

#nullable disable

namespace RoleBased.Infrastructure.Migrations
{
    [DbContext(typeof(RoleBasedDbContext))]
    partial class RoleBasedDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RoleBased.Model.LoginDB", b =>
                {
                    b.Property<string>("RegNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("RegNo");

                    b.ToTable("LoginDB");

                    b.HasData(
                        new
                        {
                            RegNo = "C183077",
                            Created = new DateTimeOffset(new DateTime(2023, 10, 5, 12, 14, 31, 105, DateTimeKind.Unspecified).AddTicks(8843), new TimeSpan(0, 6, 0, 0, 0)),
                            CreatedBy = "1",
                            LastModified = new DateTimeOffset(new DateTime(2023, 10, 5, 12, 14, 31, 105, DateTimeKind.Unspecified).AddTicks(8891), new TimeSpan(0, 6, 0, 0, 0)),
                            Pass = "12345",
                            Role = "student",
                            Status = 1
                        });
                });

            modelBuilder.Entity("RoleBased.Model.StudentInfo", b =>
                {
                    b.Property<string>("RegNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DOB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("RegNo");

                    b.ToTable("StudentInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
