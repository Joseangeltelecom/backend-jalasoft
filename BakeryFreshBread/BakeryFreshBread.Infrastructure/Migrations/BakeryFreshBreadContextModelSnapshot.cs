﻿// <auto-generated />
using System;
using BakeryFreshBread.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BakeryFreshBread.Infrastructure.Migrations
{
    [DbContext(typeof(BakeryFreshBreadContext))]
    partial class BakeryFreshBreadContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BakeryFreshBread.Core.Entities.Bread", b =>
                {
                    b.Property<int>("BreadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BreadType")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("BreadId");

                    b.ToTable("Breads");
                });

            modelBuilder.Entity("BakeryFreshBread.Core.Entities.BreadOrder", b =>
                {
                    b.Property<int>("BreadOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BreadId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("BreadOrderId");

                    b.HasIndex("BreadId");

                    b.HasIndex("OrderId");

                    b.ToTable("BreadOrders");
                });

            modelBuilder.Entity("BakeryFreshBread.Core.Entities.Office", b =>
                {
                    b.Property<int>("OfficeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BreadCapacity")
                        .HasColumnType("int");

                    b.Property<string>("OfficeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OfficeId");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("BakeryFreshBread.Core.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OfficeId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<float>("TotalCost")
                        .HasColumnType("real");

                    b.HasKey("OrderId");

                    b.HasIndex("OfficeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BakeryFreshBread.Core.Entities.BreadOrder", b =>
                {
                    b.HasOne("BakeryFreshBread.Core.Entities.Bread", "Bread")
                        .WithMany()
                        .HasForeignKey("BreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BakeryFreshBread.Core.Entities.Order", "Order")
                        .WithMany("BreadOrder")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("BakeryFreshBread.Core.Entities.Order", b =>
                {
                    b.HasOne("BakeryFreshBread.Core.Entities.Office", null)
                        .WithMany("Orders")
                        .HasForeignKey("OfficeId");
                });
#pragma warning restore 612, 618
        }
    }
}
