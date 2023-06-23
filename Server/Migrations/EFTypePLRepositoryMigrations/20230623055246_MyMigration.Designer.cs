﻿// <auto-generated />
using System;
using Lab4.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lab4.Server.Migrations.EFTypePLRepositoryMigrations
{
    [DbContext(typeof(EFTypePLRepository))]
    [Migration("20230623055246_MyMigration")]
    partial class MyMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Lab4.Shared.ProgrammingLanguage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("TypeLanguageId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TypeLanguageId");

                    b.ToTable("PLs");
                });

            modelBuilder.Entity("Lab4.Shared.TypeLanguage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TypePLs");
                });

            modelBuilder.Entity("Lab4.Shared.ProgrammingLanguage", b =>
                {
                    b.HasOne("Lab4.Shared.TypeLanguage", null)
                        .WithMany("ProgrammingLanguages")
                        .HasForeignKey("TypeLanguageId");
                });

            modelBuilder.Entity("Lab4.Shared.TypeLanguage", b =>
                {
                    b.Navigation("ProgrammingLanguages");
                });
#pragma warning restore 612, 618
        }
    }
}
