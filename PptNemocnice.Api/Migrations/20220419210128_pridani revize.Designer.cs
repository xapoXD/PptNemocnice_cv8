// <auto-generated />
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
    [Migration("20220419210128_pridani revize")]
    partial class pridanirevize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("PptNemocnice.Api.Data.Revize", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nazev")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Revizes");
                });

            modelBuilder.Entity("PptNemocnice.Api.Data.Vybaveni", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BoughtDateTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastRevision")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PriceCzk")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Vybavenis");
                });
#pragma warning restore 612, 618
        }
    }
}
