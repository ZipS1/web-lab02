using lab02.Database.Helpers;
using lab02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab02.Database.Configurations
{
    public class FlowerConfiguration : IEntityTypeConfiguration<Flower>
    {
        private const string TableName = "cd_flower";

        public void Configure(EntityTypeBuilder<Flower> builder)
        {
            builder.ToTable(TableName)
                .HasKey(p => p.FlowerId)
                .HasName($"pk_{TableName}_flower_id");

            builder.Property(p => p.FlowerId)
                .ValueGeneratedOnAdd()
                .HasColumnName("flower_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентфикатор записи цветка");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("c_flower_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название цветка");

            builder.Property(p => p.Kind)
                .HasColumnName("c_flower_kind")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Сорт цветка");

            builder.Property(p => p.AverageHeight)
                .HasColumnName("c_flower_average_height")
                .HasColumnType(ColumnType.Double)
                .HasComment("Средняя высота цветка (см)");

            builder.Property(p => p.LeafType)
                .HasColumnName("c_flower_leaf_type")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Тип листа цветка");

            builder.Property(p => p.CanBloom)
                .HasDefaultValue(true)
                .HasColumnName("c_flower_can_bloom")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Цветок может цвести?");

            builder.Property(p => p.Details)
                .HasColumnName("c_flower_details")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Дополнительные сведения о цветке");
        }
    }
}
