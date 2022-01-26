﻿// <auto-generated />
using System;
using CollectionWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CollectionWebApp.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20220123210600_AddHistoryTable")]
    partial class AddHistoryTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CollectionWebApp.Models.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TopicId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.HasIndex("UserId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("CollectionWebApp.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FromUser")
                        .HasColumnType("int");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("CollectionWebApp.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CollectionId")
                        .HasColumnType("int");

                    b.Property<int?>("ItemHistoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.HasIndex("ItemHistoryId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("CollectionWebApp.Models.ItemHistory", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ItemHistories");
                });

            modelBuilder.Entity("CollectionWebApp.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FromUser")
                        .HasColumnType("int");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("CollectionWebApp.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "user"
                        },
                        new
                        {
                            Id = 1,
                            Name = "admin"
                        });
                });

            modelBuilder.Entity("CollectionWebApp.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "block"
                        },
                        new
                        {
                            Id = 1,
                            Name = "active"
                        });
                });

            modelBuilder.Entity("CollectionWebApp.Models.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Алкоголь"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Книги"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Рецепты"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Животные"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Растения"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Одежда"
                        });
                });

            modelBuilder.Entity("CollectionWebApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("StatusId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CollectionWebApp.Models.Collection", b =>
                {
                    b.HasOne("CollectionWebApp.Models.Topic", "Topic")
                        .WithMany("Collections")
                        .HasForeignKey("TopicId");

                    b.HasOne("CollectionWebApp.Models.User", "User")
                        .WithMany("Collections")
                        .HasForeignKey("UserId");

                    b.Navigation("Topic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CollectionWebApp.Models.Comment", b =>
                {
                    b.HasOne("CollectionWebApp.Models.Item", "Item")
                        .WithMany("Comments")
                        .HasForeignKey("ItemId");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("CollectionWebApp.Models.Item", b =>
                {
                    b.HasOne("CollectionWebApp.Models.Collection", "Collection")
                        .WithMany("Items")
                        .HasForeignKey("CollectionId");

                    b.HasOne("CollectionWebApp.Models.ItemHistory", "ItemHistory")
                        .WithMany("Items")
                        .HasForeignKey("ItemHistoryId");

                    b.Navigation("Collection");

                    b.Navigation("ItemHistory");
                });

            modelBuilder.Entity("CollectionWebApp.Models.ItemHistory", b =>
                {
                    b.HasOne("CollectionWebApp.Models.User", "User")
                        .WithOne("ItemHistory")
                        .HasForeignKey("CollectionWebApp.Models.ItemHistory", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CollectionWebApp.Models.Like", b =>
                {
                    b.HasOne("CollectionWebApp.Models.Item", "Item")
                        .WithMany("Likes")
                        .HasForeignKey("ItemId");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("CollectionWebApp.Models.User", b =>
                {
                    b.HasOne("CollectionWebApp.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.HasOne("CollectionWebApp.Models.Status", "Status")
                        .WithMany("Users")
                        .HasForeignKey("StatusId");

                    b.Navigation("Role");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("CollectionWebApp.Models.Collection", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("CollectionWebApp.Models.Item", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("CollectionWebApp.Models.ItemHistory", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("CollectionWebApp.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("CollectionWebApp.Models.Status", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("CollectionWebApp.Models.Topic", b =>
                {
                    b.Navigation("Collections");
                });

            modelBuilder.Entity("CollectionWebApp.Models.User", b =>
                {
                    b.Navigation("Collections");

                    b.Navigation("ItemHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
