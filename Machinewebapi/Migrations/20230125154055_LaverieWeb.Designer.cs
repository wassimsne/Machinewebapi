﻿// <auto-generated />

using Machinewebapi.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Machinewebapi.Migrations
{
    [DbContext(typeof(LaverieAppDbContext))]
    [Migration("20230125154055_LaverieWeb")]
    partial class LaverieWeb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SharedLibrary.Models.Laverie", b =>
                {
                    b.Property<int>("IdLav")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLav"), 1L, 1);

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Responsable")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telephone")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLav");

                    b.ToTable("Laveries");
                });

            modelBuilder.Entity("SharedLibrary.Models.Machine", b =>
                {
                    b.Property<int>("IdMachine")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMachine"), 1L, 1);

                    b.Property<int>("DureeToalDeFonctionnement")
                        .HasColumnType("int");

                    b.Property<int>("IdLaverie")
                        .HasColumnType("int");

                    b.Property<int>("NumeroCode")
                        .HasColumnType("int");

                    b.Property<int>("etat")
                        .HasColumnType("int");

                    b.HasKey("IdMachine");

                    b.ToTable("Machines");
                });
#pragma warning restore 612, 618
        }
    }
}