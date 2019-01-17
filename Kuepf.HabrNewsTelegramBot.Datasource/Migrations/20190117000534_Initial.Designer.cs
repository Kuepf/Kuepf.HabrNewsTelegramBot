﻿// <auto-generated />
using System;
using Kuepf.HabrNewsTelegramBot.Datasource.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kuepf.HabrNewsTelegramBot.Datasource.Migrations
{
    [DbContext(typeof(TelegramBotContext))]
    [Migration("20190117000534_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);
                //.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kuepf.HabrNewsTelegramBot.Datasource.Models.Attributes", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid?>("TypesIDID");

                    b.HasKey("ID");

                    b.HasIndex("TypesIDID");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("Kuepf.HabrNewsTelegramBot.Datasource.Models.Objects", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid?>("TypesIDID");

                    b.HasKey("ID");

                    b.HasIndex("TypesIDID");

                    b.ToTable("Objects");
                });

            modelBuilder.Entity("Kuepf.HabrNewsTelegramBot.Datasource.Models.Parameters", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AttributeIDID");

                    b.Property<Guid?>("ObjectIDID");

                    b.Property<string>("Value");

                    b.HasKey("ID");

                    b.HasIndex("AttributeIDID");

                    b.HasIndex("ObjectIDID");

                    b.ToTable("Parameters");
                });

            modelBuilder.Entity("Kuepf.HabrNewsTelegramBot.Datasource.Models.Types", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("Kuepf.HabrNewsTelegramBot.Datasource.Models.Attributes", b =>
                {
                    b.HasOne("Kuepf.HabrNewsTelegramBot.Datasource.Models.Types", "TypesID")
                        .WithMany()
                        .HasForeignKey("TypesIDID");
                });

            modelBuilder.Entity("Kuepf.HabrNewsTelegramBot.Datasource.Models.Objects", b =>
                {
                    b.HasOne("Kuepf.HabrNewsTelegramBot.Datasource.Models.Types", "TypesID")
                        .WithMany()
                        .HasForeignKey("TypesIDID");
                });

            modelBuilder.Entity("Kuepf.HabrNewsTelegramBot.Datasource.Models.Parameters", b =>
                {
                    b.HasOne("Kuepf.HabrNewsTelegramBot.Datasource.Models.Attributes", "AttributeID")
                        .WithMany()
                        .HasForeignKey("AttributeIDID");

                    b.HasOne("Kuepf.HabrNewsTelegramBot.Datasource.Models.Objects", "ObjectID")
                        .WithMany()
                        .HasForeignKey("ObjectIDID");
                });
#pragma warning restore 612, 618
        }
    }
}
