﻿// <auto-generated />
using System;
using CFE_DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CFEDatabase.Migrations
{
    [DbContext(typeof(CFEDataBaseContext))]
    [Migration("20230610180741_llaveforaneaPrueba")]
    partial class llaveforaneaPrueba
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CFE_Domain.Devices.Devices", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("isHeavy")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isSemiInsulated")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("voltage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("CFE_Domain.Material.AmountMaterial", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("DeviceId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("DevicesId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<Guid>("materialId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("DevicesId");

                    b.HasIndex("materialId");

                    b.ToTable("AmountsMaterial");
                });

            modelBuilder.Entity("CFE_Domain.Material.Material", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<long>("Code")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("unirPrice")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("CFE_Domain.Usuario.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80d4e6e6-4137-4531-a385-2602f695924f"),
                            CreateDate = new DateTime(2023, 6, 10, 12, 7, 41, 384, DateTimeKind.Local).AddTicks(9186),
                            Password = "123456789",
                            Role = 0,
                            UpdateDate = new DateTime(2023, 6, 10, 12, 7, 41, 384, DateTimeKind.Local).AddTicks(9196),
                            Username = "Loon"
                        });
                });

            modelBuilder.Entity("CFE_Domain.Material.AmountMaterial", b =>
                {
                    b.HasOne("CFE_Domain.Devices.Devices", null)
                        .WithMany("materials")
                        .HasForeignKey("DevicesId");

                    b.HasOne("CFE_Domain.Material.Material", "material")
                        .WithMany()
                        .HasForeignKey("materialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("material");
                });

            modelBuilder.Entity("CFE_Domain.Devices.Devices", b =>
                {
                    b.Navigation("materials");
                });
#pragma warning restore 612, 618
        }
    }
}
