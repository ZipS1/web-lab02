﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using lab02.Database;

#nullable disable

namespace lab02.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("lab02.Models.Flower", b =>
                {
                    b.Property<int>("FlowerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int4")
                        .HasColumnName("flower_id")
                        .HasComment("Идентфикатор записи цветка");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FlowerId"));

                    b.Property<float?>("AverageHeight")
                        .HasColumnType("numeric(9,2)")
                        .HasColumnName("c_flower_average_height")
                        .HasComment("Средняя высота цветка (см)");

                    b.Property<bool>("CanBloom")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bool")
                        .HasDefaultValue(true)
                        .HasColumnName("c_flower_can_bloom")
                        .HasComment("Цветок может цвести?");

                    b.Property<string>("Details")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_flower_details")
                        .HasComment("Дополнительные сведения о цветке");

                    b.Property<string>("Kind")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_flower_kind")
                        .HasComment("Сорт цветка");

                    b.Property<string>("LeafType")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_flower_leaf_type")
                        .HasComment("Тип листа цветка");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_flower_name")
                        .HasComment("Название цветка");

                    b.HasKey("FlowerId")
                        .HasName("pk_cd_flower_flower_id");

                    b.ToTable("cd_flower", (string)null);
                });

            modelBuilder.Entity("lab02.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int4")
                        .HasColumnName("supplier_id")
                        .HasComment("Идентификатор записи поставщика");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SupplierId"));

                    b.Property<string>("DirectorName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_supplier_director_name")
                        .HasComment("ФИО директора фирмы поставщика");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_supplier_full_name")
                        .HasComment("Полное наименование поставщика");

                    b.Property<string>("LegalAddress")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_supplier_legal_address")
                        .HasComment("Юридический адрес поставщика");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(11)
                        .HasColumnType("varchar")
                        .HasColumnName("c_supplier_phone_number")
                        .HasComment("Номер телефона поставщика");

                    b.Property<string>("ShortName")
                        .HasMaxLength(30)
                        .HasColumnType("varchar")
                        .HasColumnName("c_supplier_short_name")
                        .HasComment("Сокращенное наименование поставщика");

                    b.HasKey("SupplierId")
                        .HasName("pk_cd_supplier_supplier_id");

                    b.ToTable("cd_supplier", (string)null);
                });

            modelBuilder.Entity("lab02.Models.Supply", b =>
                {
                    b.Property<int>("SupplyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int4")
                        .HasColumnName("supply_id")
                        .HasComment("Идентификатор записи поставки");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SupplyId"));

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("timestamp")
                        .HasColumnName("c_supply_delivery_date")
                        .HasComment("Дата поставки");

                    b.Property<int>("FlowerId")
                        .HasColumnType("int4")
                        .HasColumnName("f_flower_id")
                        .HasComment("Идентифкатор поставляемого цветка");

                    b.Property<float>("PricePerUnit")
                        .HasColumnType("numeric(9,2)")
                        .HasColumnName("c_supply_price_per_unit")
                        .HasComment("Цена за единицу цветка");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int4")
                        .HasColumnName("f_supplier_id")
                        .HasComment("Идентификатор поставщика");

                    b.Property<int>("Units")
                        .HasColumnType("int4")
                        .HasColumnName("c_supply_units")
                        .HasComment("Количество поствляемых цветков");

                    b.HasKey("SupplyId")
                        .HasName("pk_cd_supply_supply_id");

                    b.HasIndex(new[] { "FlowerId" }, "idx_cd_supply_fk_f_flower_id");

                    b.HasIndex(new[] { "SupplierId" }, "idx_cd_supply_fk_f_supplier_id");

                    b.ToTable("cd_supply", (string)null);
                });

            modelBuilder.Entity("lab02.Models.Supply", b =>
                {
                    b.HasOne("lab02.Models.Flower", "Flower")
                        .WithMany()
                        .HasForeignKey("FlowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_flower_id");

                    b.HasOne("lab02.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_supplier_id");

                    b.Navigation("Flower");

                    b.Navigation("Supplier");
                });
#pragma warning restore 612, 618
        }
    }
}
