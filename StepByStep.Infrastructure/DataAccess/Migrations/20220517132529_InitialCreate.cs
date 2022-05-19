using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StepByStep.Infrastructure.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Public");

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cep = table.Column<string>(nullable: true),
                    Road = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Complement = table.Column<string>(nullable: true),
                    Neighborhood = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdAddress = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Rg = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Address_IdAddress",
                        column: x => x.IdAddress,
                        principalSchema: "Public",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_IdAddress",
                schema: "Public",
                table: "Customer",
                column: "IdAddress",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Public");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "Public");
        }
    }
}
