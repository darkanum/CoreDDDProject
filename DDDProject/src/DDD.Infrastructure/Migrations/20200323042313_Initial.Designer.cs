﻿// <auto-generated />
using System;
using DDD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DDD.Infrastructure.Migrations
{
    [DbContext(typeof(ClientContext))]
    [Migration("20200323042313_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DDD.AplicationCore.Entity.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("DDD.AplicationCore.Entity.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("ClientProfessions");
                });

            modelBuilder.Entity("DDD.AplicationCore.Entity.ClientProfession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("ProfessionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProfessionId");

                    b.ToTable("ClientProfession");
                });

            modelBuilder.Entity("DDD.AplicationCore.Entity.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("DDD.AplicationCore.Entity.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("DDD.AplicationCore.Entity.Profession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CBO")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Professions");
                });

            modelBuilder.Entity("DDD.AplicationCore.Entity.Address", b =>
                {
                    b.HasOne("DDD.AplicationCore.Entity.Client", "Client")
                        .WithOne("Address")
                        .HasForeignKey("DDD.AplicationCore.Entity.Address", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DDD.AplicationCore.Entity.ClientProfession", b =>
                {
                    b.HasOne("DDD.AplicationCore.Entity.Client", "Client")
                        .WithMany("ClientProfessions")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DDD.AplicationCore.Entity.Profession", "Profession")
                        .WithMany("ClientProfessions")
                        .HasForeignKey("ProfessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DDD.AplicationCore.Entity.Contact", b =>
                {
                    b.HasOne("DDD.AplicationCore.Entity.Client", "Client")
                        .WithMany("Contacts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DDD.AplicationCore.Entity.Menu", b =>
                {
                    b.HasOne("DDD.AplicationCore.Entity.Menu", null)
                        .WithMany("SubMenu")
                        .HasForeignKey("MenuId");
                });
#pragma warning restore 612, 618
        }
    }
}
