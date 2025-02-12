using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JsonParser.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTables_Knot_ConstructionObject_MessageFormat_Reference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConstructionObject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Session = table.Column<string>(type: "TEXT", nullable: false),
                    MetaData = table.Column<string>(type: "TEXT", nullable: false),
                    TextData = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    MetaCode = table.Column<int>(type: "INTEGER", nullable: false),
                    DateRegistration = table.Column<string>(type: "TEXT", nullable: false),
                    IsPushed = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsProcessed = table.Column<bool>(type: "INTEGER", nullable: false),
                    BeProcessedApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    BeOutgoingConfirmation = table.Column<bool>(type: "INTEGER", nullable: false),
                    BeIncomingConfirmation = table.Column<bool>(type: "INTEGER", nullable: false),
                    BinaryData = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionObject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Group = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "References",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Group = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Method = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reference", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Knotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    ReferenceId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Knot_Reference_ReferenceId",
                        column: x => x.ReferenceId,
                        principalTable: "References",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Knot_ReferenceId",
                table: "Knotes",
                column: "ReferenceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstructionObject");

            migrationBuilder.DropTable(
                name: "Knotes");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "References");
        }
    }
}
