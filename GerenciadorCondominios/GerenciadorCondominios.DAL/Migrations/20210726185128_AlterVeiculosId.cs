using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciadorCondominios.DAL.Migrations
{
    public partial class AlterVeiculosId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "60497a21-7ede-4352-8419-2412a4744b7e");

            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "6b77d7d3-a297-4d76-8d20-3e6a83f46473");

            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "ea8dab3a-48aa-46da-b2f1-c877831f2406");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Cadastro",
                table: "Veiculos",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "Convert(Datetime, getDate(), 103)",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "VeiculoId",
                table: "Veiculos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "8d1c001a-b45f-45bc-94d4-a44fd5f1097f", "1c9078cf-0bf9-44af-8c39-e20a01c08e2a", "Morador do Prédio", "Morador", "MORADOR" });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "357ddb42-4334-4faf-858f-501eb3c423a2", "f527c822-8c2e-4425-b150-84c352a47cdb", "Síndico do Prédio", "Sindico", "SINDICO" });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "78d2651c-300e-4e51-a506-48930129593c", "2da6cb05-1add-4ccb-9d27-150a9d9623ef", "Administrador do Prédio", "Administrador", "ADMINISTRADOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "357ddb42-4334-4faf-858f-501eb3c423a2");

            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "78d2651c-300e-4e51-a506-48930129593c");

            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "8d1c001a-b45f-45bc-94d4-a44fd5f1097f");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Cadastro",
                table: "Veiculos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "Convert(Datetime, getDate(), 103)");

            migrationBuilder.AlterColumn<string>(
                name: "VeiculoId",
                table: "Veiculos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "ea8dab3a-48aa-46da-b2f1-c877831f2406", "07c4e550-99ef-4718-ae8d-3a4508029421", "Morador do Prédio", "Morador", "MORADOR" });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "60497a21-7ede-4352-8419-2412a4744b7e", "452c98fb-49c8-484b-9fa5-7b476886c1b2", "Síndico do Prédio", "Síndico", "SINDICO" });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "6b77d7d3-a297-4d76-8d20-3e6a83f46473", "6cdfd0b4-a368-4b3f-9978-0d12d552074c", "Administrador do Prédio", "Administrador", "ADMINISTRADOR" });
        }
    }
}
