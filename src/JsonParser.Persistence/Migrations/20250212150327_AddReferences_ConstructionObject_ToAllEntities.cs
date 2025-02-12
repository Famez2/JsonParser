using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JsonParser.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddReferences_ConstructionObject_ToAllEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knot_Reference_ReferenceId",
                table: "Knotes");

            migrationBuilder.AddColumn<Guid>(
                name: "ObjectId",
                table: "References",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ObjectId",
                table: "Message",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ReferenceId",
                table: "Knotes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "ObjectId",
                table: "Knotes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reference_ObjectId",
                table: "References",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ObjectId",
                table: "Message",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Knot_ObjectId",
                table: "Knotes",
                column: "ObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Knot_ConstructionObject_ObjectId",
                table: "Knotes",
                column: "ObjectId",
                principalTable: "ConstructionObject",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Knot_Reference_ReferenceId",
                table: "Knotes",
                column: "ReferenceId",
                principalTable: "References",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_ConstructionObject_ObjectId",
                table: "Message",
                column: "ObjectId",
                principalTable: "ConstructionObject",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reference_ConstructionObject_ObjectId",
                table: "References",
                column: "ObjectId",
                principalTable: "ConstructionObject",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knot_ConstructionObject_ObjectId",
                table: "Knotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Knot_Reference_ReferenceId",
                table: "Knotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_ConstructionObject_ObjectId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Reference_ConstructionObject_ObjectId",
                table: "References");

            migrationBuilder.DropIndex(
                name: "IX_Reference_ObjectId",
                table: "References");

            migrationBuilder.DropIndex(
                name: "IX_Message_ObjectId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Knot_ObjectId",
                table: "Knotes");

            migrationBuilder.DropColumn(
                name: "ObjectId",
                table: "References");

            migrationBuilder.DropColumn(
                name: "ObjectId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "ObjectId",
                table: "Knotes");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReferenceId",
                table: "Knotes",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Knot_Reference_ReferenceId",
                table: "Knotes",
                column: "ReferenceId",
                principalTable: "References",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
