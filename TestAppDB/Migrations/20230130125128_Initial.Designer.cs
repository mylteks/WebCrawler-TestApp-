﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebCrawlerDataBase;

#nullable disable

namespace WebCrawlerDataBase.Migrations
{
    [DbContext(typeof(CrawlerContext))]
    [Migration("20230130125128_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Test_app_DB.Models.RequestInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("RequestTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("Request time");

                    b.Property<string>("WebsiteName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Website Name");

                    b.HasKey("Id");

                    b.ToTable("RequestInfo");
                });

            modelBuilder.Entity("Test_app_DB.Models.RequestResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("RequestInfoId")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Source");

                    b.Property<double>("Timing")
                        .HasColumnType("float")
                        .HasColumnName("Timing");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Url");

                    b.HasKey("Id");

                    b.HasIndex("RequestInfoId");

                    b.ToTable("RequestResult");
                });

            modelBuilder.Entity("Test_app_DB.Models.RequestResult", b =>
                {
                    b.HasOne("Test_app_DB.Models.RequestInfo", null)
                        .WithMany("Results")
                        .HasForeignKey("RequestInfoId");
                });

            modelBuilder.Entity("Test_app_DB.Models.RequestInfo", b =>
                {
                    b.Navigation("Results");
                });
#pragma warning restore 612, 618
        }
    }
}
