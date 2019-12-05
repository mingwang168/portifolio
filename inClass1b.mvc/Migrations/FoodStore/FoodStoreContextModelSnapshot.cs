﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using inClass1b.mvc.Models.FoodStore;

namespace inClass1b.mvc.Migrations.FoodStore
{
    [DbContext(typeof(FoodStoreContext))]
    partial class FoodStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("inClass1b.mvc.Models.FoodStore.Building", b =>
                {
                    b.Property<string>("BuildingName")
                        .HasColumnName("building_name")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<int>("UnitNum")
                        .HasColumnName("unit_num");

                    b.Property<int?>("Capacity")
                        .HasColumnName("capacity");

                    b.HasKey("BuildingName", "UnitNum")
                        .HasName("PK__Building__14E071A090897AF2");

                    b.ToTable("Building");
                });

            modelBuilder.Entity("inClass1b.mvc.Models.FoodStore.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnName("employee_id");

                    b.Property<string>("Branch")
                        .HasColumnName("branch")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.HasKey("EmployeeId");

                    b.HasIndex("Branch");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("inClass1b.mvc.Models.FoodStore.Invoice", b =>
                {
                    b.Property<int>("InvoiceNum")
                        .HasColumnName("invoiceNum");

                    b.Property<string>("Branch")
                        .HasColumnName("branch")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.HasKey("InvoiceNum")
                        .HasName("PK__Invoice__F9EE138312C8CEBF");

                    b.HasIndex("Branch");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("inClass1b.mvc.Models.FoodStore.Manufacturer", b =>
                {
                    b.Property<string>("Mfg")
                        .HasColumnName("mfg")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<decimal?>("MfgDiscount")
                        .HasColumnName("mfgDiscount")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("Mfg")
                        .HasName("PK__Manufact__DF50190D25DA9F9B");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("inClass1b.mvc.Models.FoodStore.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnName("productID");

                    b.Property<string>("Mfg")
                        .HasColumnName("mfg")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<decimal?>("Price")
                        .HasColumnName("price")
                        .HasColumnType("money");

                    b.Property<string>("Vendor")
                        .HasColumnName("vendor")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.HasKey("ProductId");

                    b.HasIndex("Mfg");

                    b.HasIndex("Vendor");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("inClass1b.mvc.Models.FoodStore.ProductInvoice", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnName("productID");

                    b.Property<int>("InvoiceNum")
                        .HasColumnName("invoiceNum");

                    b.HasKey("ProductId", "InvoiceNum")
                        .HasName("PK__ProductI__028E307277B32FC7");

                    b.HasIndex("InvoiceNum");

                    b.ToTable("ProductInvoice");
                });

            modelBuilder.Entity("inClass1b.mvc.Models.FoodStore.ProductInvoiceWithQuantity", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnName("productID");

                    b.Property<int>("InvoiceNum")
                        .HasColumnName("invoiceNum");

                    b.Property<int?>("Quantity")
                        .HasColumnName("quantity");

                    b.HasKey("ProductId", "InvoiceNum")
                        .HasName("PK__ProductI__028E307229719E68");

                    b.HasIndex("InvoiceNum");

                    b.ToTable("ProductInvoiceWithQuantity");
                });

            modelBuilder.Entity("inClass1b.mvc.Models.FoodStore.ProductPurchaseOrder", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnName("productID");

                    b.Property<int>("PoNum")
                        .HasColumnName("po_num");

                    b.HasKey("ProductId", "PoNum")
                        .HasName("PK__ProductP__6DEC0407062BA8EE");

                    b.HasIndex("PoNum");

                    b.ToTable("ProductPurchaseOrder");
                });

            modelBuilder.Entity("inClass1b.mvc.Models.FoodStore.PurchaseOrder", b =>
                {
                    b.Property<int>("PoNum")
                        .HasColumnName("po_num");

                    b.Property<string>("Branch")
                        .HasColumnName("branch")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.HasKey("PoNum")
                        .HasName("PK__Purchase__0FCD54D59107AFC4");

                    b.HasIndex("Branch");

                    b.ToTable("PurchaseOrder");
                });

            modelBuilder.Entity("inClass1b.mvc.Models.FoodStore.Store", b =>
                {
                    b.Property<string>("Branch")
                        .HasColumnName("branch")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("BuildingName")
                        .HasColumnName("building_name")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Region")
                        .HasColumnName("region")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<int?>("UnitNum")
                        .HasColumnName("unit_num");

                    b.HasKey("Branch")
                        .HasName("PK__Store__1F84312402E4E266");

                    b.HasIndex("BuildingName", "UnitNum");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("inClass1b.mvc.Models.FoodStore.Supplier", b =>
                {
                    b.Property<string>("Vendor")
                        .HasColumnName("vendor")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("SupplierEmail")
                        .HasColumnName("supplier_email")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("Vendor")
                        .HasName("PK__Supplier__42A1EB1C33506521");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("inClass1b.mvc.Models.FoodStore.Employee", b =>
                {
                    b.HasOne("inClass1b.mvc.Models.FoodStore.Store", "BranchNavigation")
                        .WithMany("Employee")
                        .HasForeignKey("Branch")
                        .HasConstraintName("FK__Employee__branch__5629CD9C");
                });

            modelBuilder.Entity("inClass1b.mvc.Models.FoodStore.Invoice", b =>
                {
                    b.HasOne("inClass1b.mvc.Models.FoodStore.Store", "BranchNavigation")
                        .WithMany("Invoice")
                        .HasForeignKey("Branch")
                        .HasConstraintName("FK__Invoice__branch__44FF419A");
                });

            modelBuilder.Entity("inClass1b.mvc.Models.FoodStore.Product", b =>
                {
                    b.HasOne("inClass1b.mvc.Models.FoodStore.Manufacturer", "MfgNavigation")
                        .WithMany("Product")
                        .HasForeignKey("Mfg")
                        .HasConstraintName("FK__Product__mfg__3B75D760");

                    b.HasOne("inClass1b.mvc.Models.FoodStore.Supplier", "VendorNavigation")
                        .WithMany("Product")
                        .HasForeignKey("Vendor")
                        .HasConstraintName("FK__Product__vendor__3C69FB99");
                });

            modelBuilder.Entity("inClass1b.mvc.Models.FoodStore.ProductInvoice", b =>
                {
                    b.HasOne("inClass1b.mvc.Models.FoodStore.Invoice", "InvoiceNumNavigation")
                        .WithMany("ProductInvoice")
                        .HasForeignKey("InvoiceNum")
                        .HasConstraintName("FK__ProductIn__invoi__48CFD27E");

                    b.HasOne("inClass1b.mvc.Models.FoodStore.Product", "Product")
                        .WithMany("ProductInvoice")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__ProductIn__produ__47DBAE45");
                });

            modelBuilder.Entity("inClass1b.mvc.Models.FoodStore.ProductInvoiceWithQuantity", b =>
                {
                    b.HasOne("inClass1b.mvc.Models.FoodStore.Invoice", "InvoiceNumNavigation")
                        .WithMany("ProductInvoiceWithQuantity")
                        .HasForeignKey("InvoiceNum")
                        .HasConstraintName("FK__ProductIn__invoi__4CA06362");

                    b.HasOne("inClass1b.mvc.Models.FoodStore.Product", "Product")
                        .WithMany("ProductInvoiceWithQuantity")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__ProductIn__produ__4BAC3F29");
                });

            modelBuilder.Entity("inClass1b.mvc.Models.FoodStore.ProductPurchaseOrder", b =>
                {
                    b.HasOne("inClass1b.mvc.Models.FoodStore.PurchaseOrder", "PoNumNavigation")
                        .WithMany("ProductPurchaseOrder")
                        .HasForeignKey("PoNum")
                        .HasConstraintName("FK__ProductPu__po_nu__534D60F1");

                    b.HasOne("inClass1b.mvc.Models.FoodStore.Product", "Product")
                        .WithMany("ProductPurchaseOrder")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__ProductPu__produ__52593CB8");
                });

            modelBuilder.Entity("inClass1b.mvc.Models.FoodStore.PurchaseOrder", b =>
                {
                    b.HasOne("inClass1b.mvc.Models.FoodStore.Store", "BranchNavigation")
                        .WithMany("PurchaseOrder")
                        .HasForeignKey("Branch")
                        .HasConstraintName("FK__PurchaseO__branc__4F7CD00D");
                });

            modelBuilder.Entity("inClass1b.mvc.Models.FoodStore.Store", b =>
                {
                    b.HasOne("inClass1b.mvc.Models.FoodStore.Building", "Building")
                        .WithMany("Store")
                        .HasForeignKey("BuildingName", "UnitNum")
                        .HasConstraintName("FK__Store__4222D4EF");
                });
#pragma warning restore 612, 618
        }
    }
}
