﻿// <auto-generated />
using System;
using Marmara.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Marmara.Data.Migrations
{
    [DbContext(typeof(MarmaraAppContext))]
    [Migration("20211208080643_ms")]
    partial class ms
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Marmara.Entity.Entities.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Context")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("PersonId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Blogs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Context = "Bugün okul yok.",
                            Date = new DateTime(2021, 12, 8, 11, 6, 43, 241, DateTimeKind.Local).AddTicks(2028),
                            Title = "Okul yok"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Context = "Bugün okul güzel.",
                            Date = new DateTime(2021, 12, 18, 11, 6, 43, 241, DateTimeKind.Local).AddTicks(9633),
                            Title = "Okul güzel"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Context = "Tanışma toplantısına davetlisin.",
                            Date = new DateTime(2021, 12, 8, 11, 6, 43, 241, DateTimeKind.Local).AddTicks(9704),
                            Title = "Etkileşim kulübü"
                        });
                });

            modelBuilder.Entity("Marmara.Entity.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Okul"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Kulüpler"
                        });
                });

            modelBuilder.Entity("Marmara.Entity.Entities.Comments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Context")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Marmara.Entity.Entities.Blog", b =>
                {
                    b.HasOne("Marmara.Entity.Entities.Category", "Category")
                        .WithMany("Blogs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Marmara.Entity.Entities.Comments", b =>
                {
                    b.HasOne("Marmara.Entity.Entities.Blog", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("Marmara.Entity.Entities.Category", b =>
                {
                    b.Navigation("Blogs");
                });
#pragma warning restore 612, 618
        }
    }
}
