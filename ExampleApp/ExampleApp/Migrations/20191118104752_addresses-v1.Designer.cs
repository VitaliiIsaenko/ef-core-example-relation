﻿// <auto-generated />
using System;
using ExampleApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExampleApp.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20191118104752_addresses-v1")]
    partial class addressesv1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("ExampleApp.AddressDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountryId");

                    b.HasKey("Id");

                    b.ToTable("address");
                });

            modelBuilder.Entity("ExampleApp.CountryLocaleDto", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Locale");

                    b.Property<int?>("AddressDtoId");

                    b.HasKey("Id", "Locale");

                    b.HasIndex("AddressDtoId");

                    b.ToTable("address_country");
                });

            modelBuilder.Entity("ExampleApp.CountryLocaleDto", b =>
                {
                    b.HasOne("ExampleApp.AddressDto")
                        .WithMany("CountryLocale")
                        .HasForeignKey("AddressDtoId");
                });
#pragma warning restore 612, 618
        }
    }
}