﻿// <auto-generated />
using System;
using EventCode.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventCode.Migrations
{
    [DbContext(typeof(MySQLContext))]
    [Migration("20230216141108_AdicionandoStatusEmUser")]
    partial class AdicionandoStatusEmUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("EventCode.Models.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("BI")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("bi");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phone_number");

                    b.Property<string>("QrCode")
                        .IsRequired()
                        .HasColumnType("varchar(244)")
                        .HasColumnName("qrcode");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("tb_users");
                });
#pragma warning restore 612, 618
        }
    }
}
