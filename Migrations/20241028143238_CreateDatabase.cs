using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace lab02.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_flower",
                columns: table => new
                {
                    flower_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентфикатор записи цветка")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_flower_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название цветка"),
                    c_flower_kind = table.Column<string>(type: "varchar", maxLength: 100, nullable: true, comment: "Сорт цветка"),
                    c_flower_average_height = table.Column<float>(type: "numeric(9,2)", nullable: true, comment: "Средняя высота цветка (см)"),
                    c_flower_leaf_type = table.Column<string>(type: "varchar", maxLength: 100, nullable: true, comment: "Тип листа цветка"),
                    c_flower_can_bloom = table.Column<bool>(type: "bool", nullable: false, defaultValue: true, comment: "Цветок может цвести?"),
                    c_flower_details = table.Column<string>(type: "varchar", maxLength: 100, nullable: true, comment: "Дополнительные сведения о цветке")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_flower_flower_id", x => x.flower_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_supplier",
                columns: table => new
                {
                    supplier_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор записи поставщика")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_supplier_full_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Полное наименование поставщика"),
                    c_supplier_short_name = table.Column<string>(type: "varchar", maxLength: 30, nullable: true, comment: "Сокращенное наименование поставщика"),
                    c_supplier_legal_address = table.Column<string>(type: "varchar", maxLength: 100, nullable: true, comment: "Юридический адрес поставщика"),
                    c_supplier_phone_number = table.Column<string>(type: "varchar", maxLength: 11, nullable: true, comment: "Номер телефона поставщика"),
                    c_supplier_director_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: true, comment: "ФИО директора фирмы поставщика")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_supplier_supplier_id", x => x.supplier_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_supply",
                columns: table => new
                {
                    supply_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор записи поставки")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    f_flower_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентифкатор поставляемого цветка"),
                    c_supply_delivery_date = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Дата поставки"),
                    c_supply_price_per_unit = table.Column<float>(type: "numeric(9,2)", nullable: false, comment: "Цена за единицу цветка"),
                    c_supply_units = table.Column<int>(type: "int4", nullable: false, comment: "Количество поствляемых цветков"),
                    f_supplier_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор поставщика")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_supply_supply_id", x => x.supply_id);
                    table.ForeignKey(
                        name: "fk_f_flower_id",
                        column: x => x.f_flower_id,
                        principalTable: "cd_flower",
                        principalColumn: "flower_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_supplier_id",
                        column: x => x.f_supplier_id,
                        principalTable: "cd_supplier",
                        principalColumn: "supplier_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_supply_fk_f_flower_id",
                table: "cd_supply",
                column: "f_flower_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_supply_fk_f_supplier_id",
                table: "cd_supply",
                column: "f_supplier_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_supply");

            migrationBuilder.DropTable(
                name: "cd_flower");

            migrationBuilder.DropTable(
                name: "cd_supplier");
        }
    }
}
