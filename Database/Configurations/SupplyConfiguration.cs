using lab02.Database.Helpers;
using lab02.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace lab02.Database.Configurations
{
    public class SupplyConfiguration : IEntityTypeConfiguration<Supply>
    {
        private const string TableName = "cd_supply";

        public void Configure(EntityTypeBuilder<Supply> builder)
        {
            builder.ToTable(TableName)
                .HasKey(p => p.SupplyId)
                .HasName($"pk_{TableName}_supply_id");

            builder.Property(p => p.SupplyId)
                .ValueGeneratedOnAdd()
                .HasColumnName("supply_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор записи поставки");

            builder.Property(p => p.FlowerId)
                .IsRequired()
                .HasColumnName("f_flower_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентифкатор поставляемого цветка");

            builder.Property(p => p.DeliveryDate)
                .IsRequired()
                .HasColumnName("c_supply_delivery_date")
                .HasColumnType(ColumnType.DateTime)
                .HasComment("Дата поставки");

            builder.Property(p => p.PricePerUnit)
                .IsRequired()
                .HasColumnName("c_supply_price_per_unit")
                .HasColumnType(ColumnType.Money)
                .HasComment("Цена за единицу цветка");

            builder.Property(p => p.Units)
                .IsRequired()
                .HasColumnName("c_supply_units")
                .HasColumnType(ColumnType.Int)
                .HasComment("Количество поствляемых цветков");

            builder.Property(p => p.SupplierId)
                .IsRequired()
                .HasColumnName("f_supplier_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор поставщика");

            builder
                .HasOne(p => p.Flower)
                .WithMany()
                .HasForeignKey(p => p.FlowerId)
                .HasConstraintName("fk_f_flower_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(p => p.Supplier)
                .WithMany()
                .HasForeignKey(p => p.SupplierId)
                .HasConstraintName("fk_f_supplier_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(p => p.FlowerId, $"idx_{TableName}_fk_f_flower_id");
            builder.HasIndex(p => p.SupplierId, $"idx_{TableName}_fk_f_supplier_id");
        }
    }
}
