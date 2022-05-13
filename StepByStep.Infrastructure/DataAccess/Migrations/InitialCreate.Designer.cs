﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace StepByStep.Infrastructure.DataAccess.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("StepByStep.Infrastructure.DataAccess.Entities.Customer", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<bool>("Active")
                    .HasColumnType("boolean");

                b.Property<DateTime>("Birthday")
                    .HasColumnType("timestamp without time zone");

                b.Property<string>("Cpf")
                    .HasColumnType("text");

                b.Property<string>("Name")
                    .HasColumnType("text");

                b.Property<DateTime>("RegisterDate")
                    .HasColumnType("timestamp without time zone");

                b.Property<string>("Rg")
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("Customer", "public");
            });

            modelBuilder.Entity("StepByStep.Infrastructure.DataAccess.Entities.Adress", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<string>("Neighborhood")
                    .HasColumnType("text");

                b.Property<string>("Cep")
                    .HasColumnType("text");

                b.Property<string>("City")
                    .HasColumnType("text");

                b.Property<string>("Complement")
                    .HasColumnType("text");

                b.Property<Guid>("CustomerId")
                    .HasColumnType("uuid");

                b.Property<string>("State")
                    .HasColumnType("text");

                b.Property<string>("Number")
                    .HasColumnType("text");

                b.Property<string>("Road")
                    .HasColumnType("text");

                b.HasKey("Id");

                b.HasIndex("CustomerId")
                    .IsUnique();

                b.ToTable("Adress", "public");
            });

            modelBuilder.Entity("StepByStep.Infrastructure.DataAccess.Entities.Adress", b =>
            {
                b.HasOne("StepByStep.Infrastructure.DataAccess.Entities.Adress", null)
                    .WithOne("Adress")
                    .HasForeignKey("StepByStep.Infrastructure.DataAccess.Entities.Adress", "CustomerId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
#pragma warning restore 612, 618
        }
    }
}
