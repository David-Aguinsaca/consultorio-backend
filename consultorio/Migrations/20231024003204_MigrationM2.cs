using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace consultorio.Migrations
{
    /// <inheritdoc />
    public partial class MigrationM2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Insureds_IdinsuredNavigationIdInsured",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Sures_Insureds_IdinsuredNavigationIdInsured",
                table: "Sures");

            migrationBuilder.DropIndex(
                name: "IX_Sures_IdinsuredNavigationIdInsured",
                table: "Sures");

            migrationBuilder.DropColumn(
                name: "Idinsured",
                table: "Sures");

            migrationBuilder.DropColumn(
                name: "IdinsuredNavigationIdInsured",
                table: "Sures");

            migrationBuilder.RenameColumn(
                name: "IdSure",
                table: "Sures",
                newName: "Idsure");

            migrationBuilder.RenameColumn(
                name: "IdInsured",
                table: "Insureds",
                newName: "Idinsured");

            migrationBuilder.RenameColumn(
                name: "IdinsuredNavigationIdInsured",
                table: "Documents",
                newName: "IdinsuredNavigationIdinsured");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_IdinsuredNavigationIdInsured",
                table: "Documents",
                newName: "IX_Documents_IdinsuredNavigationIdinsured");

            migrationBuilder.CreateTable(
                name: "SureInsured",
                columns: table => new
                {
                    Idinsured = table.Column<int>(type: "int", nullable: false),
                    Idsure = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SureInsured", x => new { x.Idsure, x.Idinsured });
                    table.ForeignKey(
                        name: "FK_SureInsured_Insureds_Idinsured",
                        column: x => x.Idinsured,
                        principalTable: "Insureds",
                        principalColumn: "Idinsured",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SureInsured_Sures_Idsure",
                        column: x => x.Idsure,
                        principalTable: "Sures",
                        principalColumn: "Idsure",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SureInsured_Idinsured",
                table: "SureInsured",
                column: "Idinsured");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Insureds_IdinsuredNavigationIdinsured",
                table: "Documents",
                column: "IdinsuredNavigationIdinsured",
                principalTable: "Insureds",
                principalColumn: "Idinsured",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Insureds_IdinsuredNavigationIdinsured",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "SureInsured");

            migrationBuilder.RenameColumn(
                name: "Idsure",
                table: "Sures",
                newName: "IdSure");

            migrationBuilder.RenameColumn(
                name: "Idinsured",
                table: "Insureds",
                newName: "IdInsured");

            migrationBuilder.RenameColumn(
                name: "IdinsuredNavigationIdinsured",
                table: "Documents",
                newName: "IdinsuredNavigationIdInsured");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_IdinsuredNavigationIdinsured",
                table: "Documents",
                newName: "IX_Documents_IdinsuredNavigationIdInsured");

            migrationBuilder.AddColumn<int>(
                name: "Idinsured",
                table: "Sures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdinsuredNavigationIdInsured",
                table: "Sures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sures_IdinsuredNavigationIdInsured",
                table: "Sures",
                column: "IdinsuredNavigationIdInsured");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Insureds_IdinsuredNavigationIdInsured",
                table: "Documents",
                column: "IdinsuredNavigationIdInsured",
                principalTable: "Insureds",
                principalColumn: "IdInsured",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sures_Insureds_IdinsuredNavigationIdInsured",
                table: "Sures",
                column: "IdinsuredNavigationIdInsured",
                principalTable: "Insureds",
                principalColumn: "IdInsured",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
