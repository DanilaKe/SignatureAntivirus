﻿// <auto-generated />
using System;
using Antivirus.DataSourceAccess.DbModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Antivirus.DataSourceAccess.Migrations
{
    [DbContext(typeof(AntivirusContext))]
    [Migration("20190602120600_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview5.19227.1");

            modelBuilder.Entity("Antivirus.DataSourceAccess.DbModel.Signature", b =>
                {
                    b.Property<int>("SignatureId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActualSignature")
                        .IsRequired();

                    b.Property<string>("SignatureName")
                        .IsRequired();

                    b.HasKey("SignatureId");

                    b.ToTable("Signatures");
                });

            modelBuilder.Entity("Antivirus.DataSourceAccess.DbModel.Virus", b =>
                {
                    b.Property<int>("VirusId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("SignatureId")
                        .IsRequired();

                    b.HasKey("VirusId");

                    b.HasIndex("SignatureId");

                    b.ToTable("Viruses");
                });

            modelBuilder.Entity("Antivirus.DataSourceAccess.DbModel.Virus", b =>
                {
                    b.HasOne("Antivirus.DataSourceAccess.DbModel.Signature", "Signature")
                        .WithMany("Viruses")
                        .HasForeignKey("SignatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}