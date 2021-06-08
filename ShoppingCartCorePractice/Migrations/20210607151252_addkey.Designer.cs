﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingCartCorePractice.Migrations;

namespace ShoppingCartCorePractice.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210607151252_addkey")]
    partial class addkey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShoppingCartCorePractice.Migrations.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ShoppingCartCorePractice.Migrations.OrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Order_Id")
                        .HasColumnType("int");

                    b.Property<int?>("OrdersId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Product_Id")
                        .HasColumnType("int");

                    b.Property<int?>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrdersId");

                    b.HasIndex("ProductsId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("ShoppingCartCorePractice.Migrations.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BuyDT")
                        .HasColumnType("datetime2");

                    b.Property<string>("ContactAddress")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("ContactName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ContactPhone")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Memo")
                        .HasColumnType("nvarchar(300)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ShoppingCartCorePractice.Migrations.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(150)");
              
                    b.Property<int>("Category_Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(300)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PublishDT")
                        .HasColumnType("datetime2");

                    b.Property<string>("Publisher")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");                 

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ShoppingCartCorePractice.Migrations.OrderDetails", b =>
                {
                    b.HasOne("ShoppingCartCorePractice.Migrations.Orders", "Orders")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrdersId");

                    b.HasOne("ShoppingCartCorePractice.Migrations.Products", "Products")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductsId");

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShoppingCartCorePractice.Migrations.Products", b =>
                {
                    b.HasOne("ShoppingCartCorePractice.Migrations.Categories", "Categories")
                        .WithMany("Products")
                        .HasForeignKey("Category_Id");

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("ShoppingCartCorePractice.Migrations.Categories", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShoppingCartCorePractice.Migrations.Orders", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("ShoppingCartCorePractice.Migrations.Products", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
