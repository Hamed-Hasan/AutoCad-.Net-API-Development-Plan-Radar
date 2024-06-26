﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace autoCadApiDevelopment.Migrations
{
    [DbContext(typeof(AutoCadContext))]
    [Migration("20240609143430_ChangesWithImageFile-addedImagefile")]
    partial class ChangesWithImageFileaddedImagefile
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutoCADApi.Models.AutoCADFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("FileData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Urn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AutoCADFile");
                });

            modelBuilder.Entity("AutoCADApi.Models.ImageFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("FileData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Urn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ImageFiles");
                });

            modelBuilder.Entity("AutoCADApi.Models.ModalContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PinId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PinId")
                        .IsUnique();

                    b.ToTable("ModalContents");
                });

            modelBuilder.Entity("AutoCADApi.Models.Pin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("AudioClip")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("AutoCADFileId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImageFileId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("VideoClip")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AutoCADFileId");

                    b.HasIndex("ImageFileId");

                    b.ToTable("Pins");
                });

            modelBuilder.Entity("AutoCADApi.Models.ModalContent", b =>
                {
                    b.HasOne("AutoCADApi.Models.Pin", null)
                        .WithOne("ModalContent")
                        .HasForeignKey("AutoCADApi.Models.ModalContent", "PinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutoCADApi.Models.Pin", b =>
                {
                    b.HasOne("AutoCADApi.Models.AutoCADFile", "AutoCADFile")
                        .WithMany("Pins")
                        .HasForeignKey("AutoCADFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoCADApi.Models.ImageFile", "ImageFile")
                        .WithMany("Pins")
                        .HasForeignKey("ImageFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AutoCADFile");

                    b.Navigation("ImageFile");
                });

            modelBuilder.Entity("AutoCADApi.Models.AutoCADFile", b =>
                {
                    b.Navigation("Pins");
                });

            modelBuilder.Entity("AutoCADApi.Models.ImageFile", b =>
                {
                    b.Navigation("Pins");
                });

            modelBuilder.Entity("AutoCADApi.Models.Pin", b =>
                {
                    b.Navigation("ModalContent")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
