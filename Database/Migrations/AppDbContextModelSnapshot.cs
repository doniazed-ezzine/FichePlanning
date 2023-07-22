﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Models.FichePlanning", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Audite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Evaluation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FkFiliale")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FkUtilisateur")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActif")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FkFiliale");

                    b.HasIndex("FkUtilisateur");

                    b.ToTable("FichePlannings");
                });

            modelBuilder.Entity("Domain.Models.Filiale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Secteur")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Filiales");
                });

            modelBuilder.Entity("Domain.Models.Fonction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fonctions");
                });

            modelBuilder.Entity("Domain.Models.Periode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DatePlanning")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FkPlanning")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NbrJ")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FkPlanning");

                    b.ToTable("Periodes");
                });

            modelBuilder.Entity("Domain.Models.Utilisateur", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FkFonction")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActif")
                        .HasColumnType("bit");

                    b.Property<string>("Matricule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomPrenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FkFonction");

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("Domain.Models.FichePlanning", b =>
                {
                    b.HasOne("Domain.Models.Filiale", "Filiale")
                        .WithMany("FichePlannings")
                        .HasForeignKey("FkFiliale")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Utilisateur", "Utilisateur")
                        .WithMany("FichePlannings")
                        .HasForeignKey("FkUtilisateur")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filiale");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("Domain.Models.Periode", b =>
                {
                    b.HasOne("Domain.Models.FichePlanning", "FichePlanning")
                        .WithMany("Periodes")
                        .HasForeignKey("FkPlanning")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FichePlanning");
                });

            modelBuilder.Entity("Domain.Models.Utilisateur", b =>
                {
                    b.HasOne("Domain.Models.Fonction", "Fonction")
                        .WithMany("Utilisateurs")
                        .HasForeignKey("FkFonction")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fonction");
                });

            modelBuilder.Entity("Domain.Models.FichePlanning", b =>
                {
                    b.Navigation("Periodes");
                });

            modelBuilder.Entity("Domain.Models.Filiale", b =>
                {
                    b.Navigation("FichePlannings");
                });

            modelBuilder.Entity("Domain.Models.Fonction", b =>
                {
                    b.Navigation("Utilisateurs");
                });

            modelBuilder.Entity("Domain.Models.Utilisateur", b =>
                {
                    b.Navigation("FichePlannings");
                });
#pragma warning restore 612, 618
        }
    }
}