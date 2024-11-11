using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Conta.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaTransacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataTransacao = table.Column<DateTime>(type: "DATE", nullable: false, defaultValue: new DateTime(2024, 11, 8, 11, 51, 33, 525, DateTimeKind.Local).AddTicks(2137)),
                    Local = table.Column<string>(type: "varchar(30)", nullable: false),
                    TipoTransacao = table.Column<string>(type: "varchar(30)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacao");
        }
    }
}
