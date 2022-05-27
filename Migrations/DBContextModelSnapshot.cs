﻿// <auto-generated />
using System;
using DSS_Assignment_Ebube.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DSS_Assignment_Ebube.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DSS_Assignment_Ebube.Models.League", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Cup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("DSS_Assignment_Ebube.Models.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("JerseyNumber")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TeamID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("DSS_Assignment_Ebube.Models.Player_League", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LeagueId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Players_Leagues");
                });

            modelBuilder.Entity("DSS_Assignment_Ebube.Models.Team", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("YearCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("DSS_Assignment_Ebube.Models.Player", b =>
                {
                    b.HasOne("DSS_Assignment_Ebube.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamID");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("DSS_Assignment_Ebube.Models.Player_League", b =>
                {
                    b.HasOne("DSS_Assignment_Ebube.Models.League", "Leagues")
                        .WithMany("Players_Leagues")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DSS_Assignment_Ebube.Models.Player", "Players")
                        .WithMany("Players_Leagues")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Leagues");

                    b.Navigation("Players");
                });

            modelBuilder.Entity("DSS_Assignment_Ebube.Models.League", b =>
                {
                    b.Navigation("Players_Leagues");
                });

            modelBuilder.Entity("DSS_Assignment_Ebube.Models.Player", b =>
                {
                    b.Navigation("Players_Leagues");
                });

            modelBuilder.Entity("DSS_Assignment_Ebube.Models.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
