﻿// <auto-generated />
using System;
using DataAccess.Example.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Example.EntityFramework.Migrations
{
    [DbContext(typeof(VehiclesDataContext))]
    partial class VehiclesDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DataAccess.Example.Core.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("DataAccess.Example.Core.Incentive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Incentives");
                });

            modelBuilder.Entity("DataAccess.Example.Core.Inventoty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("DataAccess.Example.Core.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("MakeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("DataAccess.Example.Core.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FirstProductionYear")
                        .HasColumnType("int");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Model");
                });

            modelBuilder.Entity("DataAccess.Example.Core.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.HasIndex("ModelId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("DataAccess.Example.Core.VehicleIncentive", b =>
                {
                    b.Property<int>("IncentiveId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidTill")
                        .HasColumnType("datetime(6)");

                    b.HasKey("IncentiveId", "VehicleId");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehicleIncentive");
                });

            modelBuilder.Entity("DataAccess.Example.Core.Inventoty", b =>
                {
                    b.HasOne("DataAccess.Example.Core.Color", "Color")
                        .WithMany("inventories")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Example.Core.Vehicle", "Vehicle")
                        .WithMany("inventories")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("DataAccess.Example.Core.Vehicle", b =>
                {
                    b.HasOne("DataAccess.Example.Core.Make", "Make")
                        .WithMany("Vehicles")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Example.Core.Model", "Model")
                        .WithMany("Vehicles")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Make");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("DataAccess.Example.Core.VehicleIncentive", b =>
                {
                    b.HasOne("DataAccess.Example.Core.Incentive", "Incentive")
                        .WithMany()
                        .HasForeignKey("IncentiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Example.Core.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Incentive");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("DataAccess.Example.Core.Color", b =>
                {
                    b.Navigation("inventories");
                });

            modelBuilder.Entity("DataAccess.Example.Core.Make", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("DataAccess.Example.Core.Model", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("DataAccess.Example.Core.Vehicle", b =>
                {
                    b.Navigation("inventories");
                });
#pragma warning restore 612, 618
        }
    }
}
