﻿// <auto-generated />
using System;
using JM_Ejercicio_2_Tablas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JM_Ejercicio_2_Tablas.Migrations
{
    [DbContext(typeof(JM_Ejercicio_2_TablasContext))]
    [Migration("20230421200911_Inicio v.2")]
    partial class Iniciov2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JM_Ejercicio_2_Tablas.Models.Burger", b =>
                {
                    b.Property<int>("BurgerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BurgerID"), 1L, 1);

                    b.Property<string>("Comentarios")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("WithCheese")
                        .HasColumnType("bit");

                    b.HasKey("BurgerID");

                    b.ToTable("Burger");
                });

            modelBuilder.Entity("JM_Ejercicio_2_Tablas.Models.Promo", b =>
                {
                    b.Property<int>("PromoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PromoId"), 1L, 1);

                    b.Property<int>("BurgerId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("PromoId");

                    b.HasIndex("BurgerId");

                    b.ToTable("Promo");
                });

            modelBuilder.Entity("JM_Ejercicio_2_Tablas.Models.Promo", b =>
                {
                    b.HasOne("JM_Ejercicio_2_Tablas.Models.Burger", "Burger")
                        .WithMany("Promos")
                        .HasForeignKey("BurgerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Burger");
                });

            modelBuilder.Entity("JM_Ejercicio_2_Tablas.Models.Burger", b =>
                {
                    b.Navigation("Promos");
                });
#pragma warning restore 612, 618
        }
    }
}
