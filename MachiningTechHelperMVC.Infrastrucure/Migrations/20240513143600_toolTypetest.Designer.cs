﻿// <auto-generated />
using System;
using MachiningTechHelperMVC.Infrastrucure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MachiningTechHelperMVC.Infrastrucure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240513143600_toolTypetest")]
    partial class toolTypetest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.Drill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Diameter")
                        .HasColumnType("float");

                    b.Property<bool>("IsToolActive")
                        .HasColumnType("bit");

                    b.Property<string>("LengthXDiameter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProducerId")
                        .HasColumnType("int");

                    b.Property<int>("TeethNumber")
                        .HasColumnType("int");

                    b.Property<int>("TipAngle")
                        .HasColumnType("int");

                    b.Property<int>("ToolType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProducerId");

                    b.ToTable("Drills");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.DrillCheckedParameters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DrillId")
                        .HasColumnType("int");

                    b.Property<int>("FeedPerMinute")
                        .HasColumnType("int");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RevisionsPerMinute")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DrillId");

                    b.ToTable("DrillsCheckedParameters");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.DrillParametersRange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CuttingSpeedMaximum")
                        .HasColumnType("int");

                    b.Property<int>("CuttingSpeedMinimum")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DrillId")
                        .HasColumnType("int");

                    b.Property<double>("FeedPerRevisionMaximum")
                        .HasColumnType("float");

                    b.Property<double>("FeedPerRevisionMinimum")
                        .HasColumnType("float");

                    b.Property<string>("GradeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DrillId");

                    b.ToTable("DrillParametersRanges");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.MillingInsert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Radius")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("MillingInserts");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.MillingInsertParametersRange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CuttingSpeedMaximum")
                        .HasColumnType("int");

                    b.Property<int>("CuttingSpeedMinimum")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FeedPerToothMaximum")
                        .HasColumnType("float");

                    b.Property<double>("FeedPerToothMinimum")
                        .HasColumnType("float");

                    b.Property<string>("GradeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MillingInsertId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MillingInsertId");

                    b.ToTable("MillingInsertParametersRange");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.MillingTool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Diameter")
                        .HasColumnType("float");

                    b.Property<bool>("IsToolActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ProducerId")
                        .HasColumnType("int");

                    b.Property<int>("TeethNumber")
                        .HasColumnType("int");

                    b.Property<int>("ToolType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProducerId");

                    b.ToTable("MillingTools");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.MillingToolCheckedParameters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CuttingDepth")
                        .HasColumnType("float");

                    b.Property<int>("FeedPerMinute")
                        .HasColumnType("int");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MillingToolId")
                        .HasColumnType("int");

                    b.Property<int>("RevisionsPerMinute")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MillingToolId");

                    b.ToTable("MillingToolsCheckedParameters");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.MillingToolMillingInsert", b =>
                {
                    b.Property<int>("MillingToolId")
                        .HasColumnType("int");

                    b.Property<int>("MillingInsertId")
                        .HasColumnType("int");

                    b.HasKey("MillingToolId", "MillingInsertId");

                    b.HasIndex("MillingInsertId");

                    b.ToTable("MillingToolMillingInserts");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.SolidMillingTool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Diameter")
                        .HasColumnType("float");

                    b.Property<bool>("IsToolActive")
                        .HasColumnType("bit");

                    b.Property<int>("Lcut")
                        .HasColumnType("int");

                    b.Property<int?>("ProducerId")
                        .HasColumnType("int");

                    b.Property<double>("Radius")
                        .HasColumnType("float");

                    b.Property<int>("TeethNumber")
                        .HasColumnType("int");

                    b.Property<int>("ToolType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProducerId");

                    b.ToTable("SolidMillingTools");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.SolidMillingToolCheckedParameters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FeedPerMinute")
                        .HasColumnType("int");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RevisionsPerMinute")
                        .HasColumnType("int");

                    b.Property<int>("SolidMillingToolId")
                        .HasColumnType("int");

                    b.Property<double>("cuttingDepth")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("SolidMillingToolId");

                    b.ToTable("SolidMillingToolsCheckedParameters");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.SolidMillingToolParametersRange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CuttingSpeedMaximum")
                        .HasColumnType("int");

                    b.Property<int>("CuttingSpeedMinimum")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FeedPerToothMaximum")
                        .HasColumnType("float");

                    b.Property<double>("FeedPerToothMinimum")
                        .HasColumnType("float");

                    b.Property<string>("GradeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SolidMillingToolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SolidMillingToolId");

                    b.ToTable("SolidMillingToolParametersRanges");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.Drill", b =>
                {
                    b.HasOne("MachiningTechHelperMVC.Domain.Model.Producer", "Producer")
                        .WithMany("Drills")
                        .HasForeignKey("ProducerId");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.DrillCheckedParameters", b =>
                {
                    b.HasOne("MachiningTechHelperMVC.Domain.Model.Drill", "Drill")
                        .WithMany("DrillCheckedParameters")
                        .HasForeignKey("DrillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drill");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.DrillParametersRange", b =>
                {
                    b.HasOne("MachiningTechHelperMVC.Domain.Model.Drill", "Drill")
                        .WithMany("DrillParametersRanges")
                        .HasForeignKey("DrillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drill");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.MillingInsertParametersRange", b =>
                {
                    b.HasOne("MachiningTechHelperMVC.Domain.Model.MillingInsert", "MillingInsert")
                        .WithMany("MillingInsertParametersRanges")
                        .HasForeignKey("MillingInsertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MillingInsert");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.MillingTool", b =>
                {
                    b.HasOne("MachiningTechHelperMVC.Domain.Model.Producer", "Producer")
                        .WithMany("MillingTools")
                        .HasForeignKey("ProducerId");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.MillingToolCheckedParameters", b =>
                {
                    b.HasOne("MachiningTechHelperMVC.Domain.Model.MillingTool", "MillingTool")
                        .WithMany("MillingToolCheckedParameters")
                        .HasForeignKey("MillingToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MillingTool");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.MillingToolMillingInsert", b =>
                {
                    b.HasOne("MachiningTechHelperMVC.Domain.Model.MillingInsert", "MillingInsert")
                        .WithMany("MillingToolMillingInserts")
                        .HasForeignKey("MillingInsertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MachiningTechHelperMVC.Domain.Model.MillingTool", "MillingTool")
                        .WithMany("MillingToolMillingInserts")
                        .HasForeignKey("MillingToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MillingInsert");

                    b.Navigation("MillingTool");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.SolidMillingTool", b =>
                {
                    b.HasOne("MachiningTechHelperMVC.Domain.Model.Producer", "Producer")
                        .WithMany("SolidMillingTools")
                        .HasForeignKey("ProducerId");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.SolidMillingToolCheckedParameters", b =>
                {
                    b.HasOne("MachiningTechHelperMVC.Domain.Model.SolidMillingTool", "SolidMillingTool")
                        .WithMany("SolidMillingToolCheckedParameters")
                        .HasForeignKey("SolidMillingToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SolidMillingTool");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.SolidMillingToolParametersRange", b =>
                {
                    b.HasOne("MachiningTechHelperMVC.Domain.Model.SolidMillingTool", "SolidMillingTool")
                        .WithMany("SolidMillingToolParametersRanges")
                        .HasForeignKey("SolidMillingToolId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("SolidMillingTool");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.Drill", b =>
                {
                    b.Navigation("DrillCheckedParameters");

                    b.Navigation("DrillParametersRanges");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.MillingInsert", b =>
                {
                    b.Navigation("MillingInsertParametersRanges");

                    b.Navigation("MillingToolMillingInserts");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.MillingTool", b =>
                {
                    b.Navigation("MillingToolCheckedParameters");

                    b.Navigation("MillingToolMillingInserts");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.Producer", b =>
                {
                    b.Navigation("Drills");

                    b.Navigation("MillingTools");

                    b.Navigation("SolidMillingTools");
                });

            modelBuilder.Entity("MachiningTechHelperMVC.Domain.Model.SolidMillingTool", b =>
                {
                    b.Navigation("SolidMillingToolCheckedParameters");

                    b.Navigation("SolidMillingToolParametersRanges");
                });
#pragma warning restore 612, 618
        }
    }
}
