﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PFE_API;

#nullable disable

namespace PFE_API.Migrations
{
    [DbContext(typeof(DBcontext))]
    [Migration("20240418112733_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PFE_API.Model.ContratRT", b =>
                {
                    b.Property<string>("CodeContrat")
                        .HasColumnType("text");

                    b.Property<bool>("Actif")
                        .HasColumnType("boolean");

                    b.Property<string>("CategorieContrat")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateFin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateFinPeriodeEssai")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MatriculeEmp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Poste")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RegimeTravail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CodeContrat");

                    b.ToTable("ContratsRT");
                });
#pragma warning restore 612, 618
        }
    }
}
