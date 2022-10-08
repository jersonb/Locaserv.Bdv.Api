﻿// <auto-generated />
using System;
using Locaserv.Bdv.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Locaserv.Bdv.Api.Data.Migrations
{
    [DbContext(typeof(LocaservContext))]
    [Migration("20221008161509_TestDates")]
    partial class TestDates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("bdv")
                .HasAnnotation("Npgsql:DatabaseTemplate", "locaserv")
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Locaserv.Bdv.Api.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateOnly")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateTimeOffset")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<TimeOnly>("TimeOnly")
                        .HasColumnType("time without time zone");

                    b.HasKey("Id");

                    b.ToTable("test", "bdv");
                });
#pragma warning restore 612, 618
        }
    }
}