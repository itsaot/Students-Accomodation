﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication20.Data;

#nullable disable

namespace WebApplication20.Migrations.RoomCondition
{
    [DbContext(typeof(RoomConditionContext))]
    [Migration("20240501113052_room4")]
    partial class room4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication20.Models.RoomCondition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("chair")
                        .HasColumnType("int");

                    b.Property<int>("fridge")
                        .HasColumnType("int");

                    b.Property<int>("lightSwitches")
                        .HasColumnType("int");

                    b.Property<int>("mattress")
                        .HasColumnType("int");

                    b.Property<int>("stove")
                        .HasColumnType("int");

                    b.Property<int>("studyDesk")
                        .HasColumnType("int");

                    b.Property<int>("wallSocket")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RoomCondition");
                });
#pragma warning restore 612, 618
        }
    }
}
