﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PptNemocnice.Api.Data;

#nullable disable

namespace PptNemocnice.Api.Migrations
{
    [DbContext(typeof(NemocniceDBcontext))]
    [Migration("20220517133802_pracovniks")]
    partial class pracovniks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("PptNemocnice.Api.Data.Pracovnik", b =>
                {
                    b.Property<Guid>("PracovnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PracovnikId");

                    b.ToTable("Pracovniks");

                    b.HasData(
                        new
                        {
                            PracovnikId = new Guid("8ae660c7-7660-436b-9bed-ca76faa2c617"),
                            Name = "Paroubek"
                        },
                        new
                        {
                            PracovnikId = new Guid("071c0f36-82c6-4ecc-ac8e-37130ef35226"),
                            Name = "Navara"
                        },
                        new
                        {
                            PracovnikId = new Guid("547184e4-9a55-4172-9ffb-7ece02cd29c3"),
                            Name = "Reichl"
                        });
                });

            modelBuilder.Entity("PptNemocnice.Api.Data.Revize", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nazev")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("VybaveniId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("VybaveniId");

                    b.ToTable("Revizes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("682b9a37-b704-4c1d-903d-6136863e08f8"),
                            DateTime = new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nazev = "idk dalsi",
                            VybaveniId = new Guid("a7fa8ef0-a548-4e68-9af1-03634b1abbba")
                        },
                        new
                        {
                            Id = new Guid("775aee54-29a7-4a4d-8fac-f8c461e2f9e8"),
                            DateTime = new DateTime(2014, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nazev = "idk dalsi2",
                            VybaveniId = new Guid("c58712b5-bbfa-490e-9582-359128cd870e")
                        },
                        new
                        {
                            Id = new Guid("9f659f58-2e09-47cc-a5f2-fefa3a73ef17"),
                            DateTime = new DateTime(2017, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nazev = "idk dalsi3",
                            VybaveniId = new Guid("4b8b4826-bc08-4346-b11f-5636dbdb31e0")
                        });
                });

            modelBuilder.Entity("PptNemocnice.Api.Data.Ukon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("JmenoPacient")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PracovnikId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PrijmeniPacient")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UkonDateTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("VybaveniId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PracovnikId");

                    b.HasIndex("VybaveniId");

                    b.ToTable("Ukons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("148bf078-5d39-47ef-a465-889ede7d2062"),
                            JmenoPacient = "Johnny",
                            Name = "scan",
                            PrijmeniPacient = "Karasek",
                            UkonDateTime = new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VybaveniId = new Guid("a7fa8ef0-a548-4e68-9af1-03634b1abbba")
                        },
                        new
                        {
                            Id = new Guid("d72872dc-47d4-4f5c-95a3-78c50c936c25"),
                            JmenoPacient = "Paul",
                            Name = "probmemek",
                            PrijmeniPacient = "Puta",
                            UkonDateTime = new DateTime(2014, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VybaveniId = new Guid("c58712b5-bbfa-490e-9582-359128cd870e")
                        },
                        new
                        {
                            Id = new Guid("f136bbaa-faa7-4343-b29e-9887c767b265"),
                            JmenoPacient = "Dave",
                            Name = "profiscan",
                            PrijmeniPacient = "Paid",
                            UkonDateTime = new DateTime(2017, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VybaveniId = new Guid("4b8b4826-bc08-4346-b11f-5636dbdb31e0")
                        });
                });

            modelBuilder.Entity("PptNemocnice.Api.Data.Vybaveni", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BoughtDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PriceCzk")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Vybavenis");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a7fa8ef0-a548-4e68-9af1-03634b1abbba"),
                            BoughtDateTime = new DateTime(2015, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "RNTGN",
                            PriceCzk = 150000
                        },
                        new
                        {
                            Id = new Guid("c58712b5-bbfa-490e-9582-359128cd870e"),
                            BoughtDateTime = new DateTime(2015, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "CT",
                            PriceCzk = 200000
                        },
                        new
                        {
                            Id = new Guid("4b8b4826-bc08-4346-b11f-5636dbdb31e0"),
                            BoughtDateTime = new DateTime(2015, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "IDK",
                            PriceCzk = 69
                        });
                });

            modelBuilder.Entity("PptNemocnice.Api.Data.Revize", b =>
                {
                    b.HasOne("PptNemocnice.Api.Data.Vybaveni", "Vybaveni")
                        .WithMany("Revizes")
                        .HasForeignKey("VybaveniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vybaveni");
                });

            modelBuilder.Entity("PptNemocnice.Api.Data.Ukon", b =>
                {
                    b.HasOne("PptNemocnice.Api.Data.Pracovnik", "Pracovnik")
                        .WithMany("Ukons")
                        .HasForeignKey("PracovnikId");

                    b.HasOne("PptNemocnice.Api.Data.Vybaveni", "Vybaveni")
                        .WithMany("Ukons")
                        .HasForeignKey("VybaveniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pracovnik");

                    b.Navigation("Vybaveni");
                });

            modelBuilder.Entity("PptNemocnice.Api.Data.Pracovnik", b =>
                {
                    b.Navigation("Ukons");
                });

            modelBuilder.Entity("PptNemocnice.Api.Data.Vybaveni", b =>
                {
                    b.Navigation("Revizes");

                    b.Navigation("Ukons");
                });
#pragma warning restore 612, 618
        }
    }
}
