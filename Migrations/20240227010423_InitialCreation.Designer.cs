﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoLoja.DataBase.MyDbContext;

#nullable disable

namespace ProjetoLoja.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240227010423_InitialCreation")]
    partial class InitialCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("CartXProduct", b =>
                {
                    b.Property<int>("Fk_CartId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Fk_ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Fk_CartId", "Fk_ProductId");

                    b.HasIndex("Fk_ProductId");

                    b.ToTable("CartXProduct");
                });

            modelBuilder.Entity("OrderXProduct", b =>
                {
                    b.Property<int>("Fk_OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Fk_ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Fk_OrderId", "Fk_ProductId");

                    b.HasIndex("Fk_ProductId");

                    b.ToTable("OrderXProduct");
                });

            modelBuilder.Entity("ProjetoLoja.Models.Cart", b =>
                {
                    b.Property<int>("Pk_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME");

                    b.Property<Guid>("Fk_UserId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("BOOLEAN");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("DATETIME");

                    b.HasKey("Pk_Id");

                    b.HasIndex("Fk_UserId");

                    b.ToTable("Carts", (string)null);
                });

            modelBuilder.Entity("ProjetoLoja.Models.Order", b =>
                {
                    b.Property<int>("Pk_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("Fk_UserId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("DATETIME");

                    b.Property<string>("OrderState")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("DATETIME");

                    b.HasKey("Pk_Id");

                    b.HasIndex("Fk_UserId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("ProjetoLoja.Models.Product", b =>
                {
                    b.Property<int>("Pk_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Size")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("DATETIME");

                    b.HasKey("Pk_Id");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("ProjetoLoja.Models.User", b =>
                {
                    b.Property<Guid>("Pk_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("BOOLEAN");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("DATETIME");

                    b.HasKey("Pk_Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("CartXProduct", b =>
                {
                    b.HasOne("ProjetoLoja.Models.Cart", null)
                        .WithMany()
                        .HasForeignKey("Fk_CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Fk_CartXProduct_CartId");

                    b.HasOne("ProjetoLoja.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("Fk_ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Fk_CartXProduct_ProductId");
                });

            modelBuilder.Entity("OrderXProduct", b =>
                {
                    b.HasOne("ProjetoLoja.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("Fk_OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Fk_OrderXProduct_OrderId");

                    b.HasOne("ProjetoLoja.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("Fk_ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Fk_OrderXProduct_ProductId");
                });

            modelBuilder.Entity("ProjetoLoja.Models.Cart", b =>
                {
                    b.HasOne("ProjetoLoja.Models.User", "User")
                        .WithMany("Carts")
                        .HasForeignKey("Fk_UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Fk_CartXUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjetoLoja.Models.Order", b =>
                {
                    b.HasOne("ProjetoLoja.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("Fk_UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Fk_OrderXUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjetoLoja.Models.User", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
