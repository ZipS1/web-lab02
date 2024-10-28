using lab02.Database.Helpers;
using lab02.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace lab02.Database.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        private const string TableName = "cd_supplier";

        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder
                .ToTable(TableName)
                .HasKey(p => p.SupplierId)
                .HasName($"pk_{TableName}_supplier_id");

            builder.Property(p => p.SupplierId)
                .ValueGeneratedOnAdd()
                .HasColumnName("supplier_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор записи поставщика");

            builder.Property(p => p.FullName)
                .IsRequired()
                .HasColumnName("c_supplier_full_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Полное наименование поставщика");

            builder.Property(p => p.ShortName)
                .HasColumnName("c_supplier_short_name")
                .HasColumnType(ColumnType.String).HasMaxLength(30)
                .HasComment("Сокращенное наименование поставщика");

            builder.Property(p => p.LegalAddress)
                .HasColumnName("c_supplier_legal_address")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Юридический адрес поставщика");

            builder.Property(p => p.PhoneNumber)
                .HasColumnName("c_supplier_phone_number")
                .HasColumnType(ColumnType.String).HasMaxLength(11)
                .HasComment("Номер телефона поставщика");

            builder.Property(p => p.DirectorName)
                .HasColumnName("c_supplier_director_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("ФИО директора фирмы поставщика");
        }
    }
}
