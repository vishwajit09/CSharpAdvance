﻿// <auto-generated />
using System;
using EntityFrameworkTask2.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameworkTask2.Migrations
{
    [DbContext(typeof(FileDbContext))]
    partial class FileDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityFrameworkTask2.Database.Models.FileInfomation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FolderId")
                        .HasColumnType("int");

                    b.Property<string>("FullPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.ToTable("FileInfomations");
                });

            modelBuilder.Entity("EntityFrameworkTask2.Database.Models.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("EntityFrameworkTask2.Database.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("FileInfomationTag", b =>
                {
                    b.Property<int>("FileInfomationsId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("FileInfomationsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("FileInfomationTag");
                });

            modelBuilder.Entity("EntityFrameworkTask2.Database.Models.FileInfomation", b =>
                {
                    b.HasOne("EntityFrameworkTask2.Database.Models.Folder", "Folder")
                        .WithMany("FileInfomations")
                        .HasForeignKey("FolderId");

                    b.Navigation("Folder");
                });

            modelBuilder.Entity("FileInfomationTag", b =>
                {
                    b.HasOne("EntityFrameworkTask2.Database.Models.FileInfomation", null)
                        .WithMany()
                        .HasForeignKey("FileInfomationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameworkTask2.Database.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameworkTask2.Database.Models.Folder", b =>
                {
                    b.Navigation("FileInfomations");
                });
#pragma warning restore 612, 618
        }
    }
}
