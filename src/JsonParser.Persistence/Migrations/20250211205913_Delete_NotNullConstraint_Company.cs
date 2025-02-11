using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JsonParser.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Delete_NotNullConstraint_Company : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "company",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "company",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "company",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "company",
                newName: "registration_date");

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "company",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "company",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "company",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "registration_date",
                table: "company",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phone",
                table: "company",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "company",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "company",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "registration_date",
                table: "company",
                newName: "RegistrationDate");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "company",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "company",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "company",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "company",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
