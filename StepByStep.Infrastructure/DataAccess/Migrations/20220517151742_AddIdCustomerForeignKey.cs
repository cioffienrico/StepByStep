using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StepByStep.Infrastructure.DataAccess.Migrations
{
    public partial class AddIdCustomerForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Address_IdAddress",
                schema: "Public",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_IdAddress",
                schema: "Public",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IdAddress",
                schema: "Public",
                table: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                schema: "Public",
                table: "Customer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Public",
                table: "Customer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                schema: "Public",
                table: "Customer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                schema: "Public",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Road",
                schema: "Public",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                schema: "Public",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Neighborhood",
                schema: "Public",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Complement",
                schema: "Public",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                schema: "Public",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                schema: "Public",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                schema: "Public",
                table: "Address",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerId",
                schema: "Public",
                table: "Address",
                column: "CustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Customer_CustomerId",
                schema: "Public",
                table: "Address",
                column: "CustomerId",
                principalSchema: "Public",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Customer_CustomerId",
                schema: "Public",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_CustomerId",
                schema: "Public",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "Public",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                schema: "Public",
                table: "Customer",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Public",
                table: "Customer",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                schema: "Public",
                table: "Customer",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<Guid>(
                name: "IdAddress",
                schema: "Public",
                table: "Customer",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "State",
                schema: "Public",
                table: "Address",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Road",
                schema: "Public",
                table: "Address",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                schema: "Public",
                table: "Address",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Neighborhood",
                schema: "Public",
                table: "Address",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Complement",
                schema: "Public",
                table: "Address",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "City",
                schema: "Public",
                table: "Address",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                schema: "Public",
                table: "Address",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Customer_IdAddress",
                schema: "Public",
                table: "Customer",
                column: "IdAddress",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Address_IdAddress",
                schema: "Public",
                table: "Customer",
                column: "IdAddress",
                principalSchema: "Public",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
