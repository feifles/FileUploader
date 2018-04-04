﻿// <auto-generated />
using FileUploaderV2.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FileUploaderV2.Migrations
{
    [DbContext(typeof(FileUploaderDbContext))]
    [Migration("20180404195402_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FileUploaderV2.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("FileUploaderV2.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("FileUploaderV2.Models.DataFileTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupId");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("LastUpdateUsername")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Template")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("DataFileTemplates");
                });

            modelBuilder.Entity("FileUploaderV2.Models.DBConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DatabaseName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Server")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("DBConfigs");
                });

            modelBuilder.Entity("FileUploaderV2.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyId");

                    b.Property<int>("DBConfigId");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("isActive");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DBConfigId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("FileUploaderV2.Models.GroupAppUser", b =>
                {
                    b.Property<int>("GroupId");

                    b.Property<int>("AppUserId");

                    b.HasKey("GroupId", "AppUserId");

                    b.HasIndex("AppUserId");

                    b.ToTable("GroupAppUsers");
                });

            modelBuilder.Entity("FileUploaderV2.Models.DataFileTemplate", b =>
                {
                    b.HasOne("FileUploaderV2.Models.Group", "Group")
                        .WithMany("DataFileTemplates")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FileUploaderV2.Models.Group", b =>
                {
                    b.HasOne("FileUploaderV2.Models.Company", "Company")
                        .WithMany("Groups")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FileUploaderV2.Models.DBConfig", "DBConfig")
                        .WithMany()
                        .HasForeignKey("DBConfigId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FileUploaderV2.Models.GroupAppUser", b =>
                {
                    b.HasOne("FileUploaderV2.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FileUploaderV2.Models.Group", "Group")
                        .WithMany("AppUsers")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
