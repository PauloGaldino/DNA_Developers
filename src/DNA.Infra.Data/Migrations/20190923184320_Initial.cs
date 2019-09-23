using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DNA.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "Varchar(150)", nullable: false),
                    Descricao = table.Column<string>(type: "Varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomeCompanhia = table.Column<string>(type: "Varchar(200)", nullable: false),
                    NomeContato = table.Column<string>(type: "Varchar(200)", nullable: false),
                    TituloContato = table.Column<string>(type: "Varchar(200)", nullable: false),
                    Telefone = table.Column<string>(type: "Varchar(50)", nullable: false),
                    EnderecoEmail = table.Column<string>(type: "Varchar(200)", nullable: false),
                    Endereco = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(type: "Varchar(200)", nullable: false),
                    Estado = table.Column<string>(type: "Varchar(150)", nullable: false),
                    Pais = table.Column<string>(type: "Varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Fornecedores");
        }
    }
}
