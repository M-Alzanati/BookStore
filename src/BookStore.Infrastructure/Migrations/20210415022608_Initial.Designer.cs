﻿// <auto-generated />
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStore.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210415022608_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("BookStore.Core.Entities.Author", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NationalityId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.HasKey("Id");

                    b.HasIndex("NationalityId");

                    b.HasIndex("TenantId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookStore.Core.Entities.Book", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(767)");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(767)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("TenantId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookStore.Core.Entities.Category", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BookStore.Core.Entities.Nationality", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Nationalities");
                });

            modelBuilder.Entity("BookStore.Core.Entities.Review", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(767)");

                    b.Property<string>("BookId")
                        .HasColumnType("varchar(767)");

                    b.Property<byte>("Rating")
                        .HasColumnType("tinyint");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("TenantId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("BookStore.Core.Entities.Tenant", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(767)");

                    b.Property<string>("ApiKey")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("BookStore.Core.Entities.Author", b =>
                {
                    b.HasOne("BookStore.Core.Entities.Nationality", "Nationality")
                        .WithMany("Authors")
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Core.Entities.Tenant", "Tenant")
                        .WithMany("Authors")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nationality");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("BookStore.Core.Entities.Book", b =>
                {
                    b.HasOne("BookStore.Core.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Core.Entities.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId");

                    b.HasOne("BookStore.Core.Entities.Tenant", "Tenant")
                        .WithMany("Books")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Category");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("BookStore.Core.Entities.Category", b =>
                {
                    b.HasOne("BookStore.Core.Entities.Tenant", "Tenant")
                        .WithMany("Categories")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("BookStore.Core.Entities.Nationality", b =>
                {
                    b.HasOne("BookStore.Core.Entities.Tenant", "Tenant")
                        .WithMany("Nationalities")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("BookStore.Core.Entities.Review", b =>
                {
                    b.HasOne("BookStore.Core.Entities.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId");

                    b.HasOne("BookStore.Core.Entities.Tenant", "Tenant")
                        .WithMany("Reviews")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("BookStore.Core.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookStore.Core.Entities.Book", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("BookStore.Core.Entities.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookStore.Core.Entities.Nationality", b =>
                {
                    b.Navigation("Authors");
                });

            modelBuilder.Entity("BookStore.Core.Entities.Tenant", b =>
                {
                    b.Navigation("Authors");

                    b.Navigation("Books");

                    b.Navigation("Categories");

                    b.Navigation("Nationalities");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}