﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using consultorio.Models;

#nullable disable

namespace consultorio.Migrations
{
    [DbContext(typeof(ConsultorioDbContext))]
    [Migration("20231022200333_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("consultorio.Models.Document", b =>
                {
                    b.Property<int>("Iddocument")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Iddocument"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extenextension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Idinsured")
                        .HasColumnType("int");

                    b.Property<int>("IdinsuredNavigationIdInsured")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Iddocument");

                    b.HasIndex("IdinsuredNavigationIdInsured");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("consultorio.Models.Insured", b =>
                {
                    b.Property<int>("IdInsured")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInsured"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdInsured");

                    b.ToTable("Insureds");
                });

            modelBuilder.Entity("consultorio.Models.Sure", b =>
                {
                    b.Property<int>("IdSure")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSure"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Idinsured")
                        .HasColumnType("int");

                    b.Property<int>("IdinsuredNavigationIdInsured")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Prima")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Sumassured")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdSure");

                    b.HasIndex("IdinsuredNavigationIdInsured");

                    b.ToTable("Sures");
                });

            modelBuilder.Entity("consultorio.Models.Document", b =>
                {
                    b.HasOne("consultorio.Models.Insured", "IdinsuredNavigation")
                        .WithMany("Documents")
                        .HasForeignKey("IdinsuredNavigationIdInsured")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdinsuredNavigation");
                });

            modelBuilder.Entity("consultorio.Models.Sure", b =>
                {
                    b.HasOne("consultorio.Models.Insured", "IdinsuredNavigation")
                        .WithMany("Sures")
                        .HasForeignKey("IdinsuredNavigationIdInsured")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdinsuredNavigation");
                });

            modelBuilder.Entity("consultorio.Models.Insured", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("Sures");
                });
#pragma warning restore 612, 618
        }
    }
}
