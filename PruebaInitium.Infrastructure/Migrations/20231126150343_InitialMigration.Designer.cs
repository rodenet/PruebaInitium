﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaInitium.Infrastructure;

namespace PruebaInitium.Infrastructure.Migrations
{
    [DbContext(typeof(AthleteContext))]
    [Migration("20231126150343_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PruebaInitium.Domain.Entities.Athlete", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Athletes");
                });

            modelBuilder.Entity("PruebaInitium.Domain.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("91990c4e-6aea-4b16-a14d-3cb78503d146"),
                            Code = "ESP"
                        },
                        new
                        {
                            Id = new Guid("e65f0820-ad0c-43fb-aa66-77ea63e910b9"),
                            Code = "ARG"
                        },
                        new
                        {
                            Id = new Guid("ea4c9d6d-b826-40e2-bf6f-e4cd9ae227ed"),
                            Code = "COL"
                        });
                });

            modelBuilder.Entity("PruebaInitium.Domain.Entities.Entry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AthleteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AthleteId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("PruebaInitium.Domain.Entities.Athlete", b =>
                {
                    b.HasOne("PruebaInitium.Domain.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("PruebaInitium.Domain.Entities.Entry", b =>
                {
                    b.HasOne("PruebaInitium.Domain.Entities.Athlete", "Athlete")
                        .WithMany("Entries")
                        .HasForeignKey("AthleteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Athlete");
                });

            modelBuilder.Entity("PruebaInitium.Domain.Entities.Athlete", b =>
                {
                    b.Navigation("Entries");
                });
#pragma warning restore 612, 618
        }
    }
}
