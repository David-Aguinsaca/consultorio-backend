using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace consultorio.Migrations
{
    /// <inheritdoc />
    public partial class Migracion3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SureInsured_Insureds_Idinsured",
                table: "SureInsured");

            migrationBuilder.DropForeignKey(
                name: "FK_SureInsured_Sures_Idsure",
                table: "SureInsured");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SureInsured",
                table: "SureInsured");

            migrationBuilder.RenameTable(
                name: "SureInsured",
                newName: "SureInsureds");

            migrationBuilder.RenameIndex(
                name: "IX_SureInsured_Idinsured",
                table: "SureInsureds",
                newName: "IX_SureInsureds_Idinsured");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SureInsureds",
                table: "SureInsureds",
                columns: new[] { "Idsure", "Idinsured" });

            migrationBuilder.AddForeignKey(
                name: "FK_SureInsureds_Insureds_Idinsured",
                table: "SureInsureds",
                column: "Idinsured",
                principalTable: "Insureds",
                principalColumn: "Idinsured",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SureInsureds_Sures_Idsure",
                table: "SureInsureds",
                column: "Idsure",
                principalTable: "Sures",
                principalColumn: "Idsure",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SureInsureds_Insureds_Idinsured",
                table: "SureInsureds");

            migrationBuilder.DropForeignKey(
                name: "FK_SureInsureds_Sures_Idsure",
                table: "SureInsureds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SureInsureds",
                table: "SureInsureds");

            migrationBuilder.RenameTable(
                name: "SureInsureds",
                newName: "SureInsured");

            migrationBuilder.RenameIndex(
                name: "IX_SureInsureds_Idinsured",
                table: "SureInsured",
                newName: "IX_SureInsured_Idinsured");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SureInsured",
                table: "SureInsured",
                columns: new[] { "Idsure", "Idinsured" });

            migrationBuilder.AddForeignKey(
                name: "FK_SureInsured_Insureds_Idinsured",
                table: "SureInsured",
                column: "Idinsured",
                principalTable: "Insureds",
                principalColumn: "Idinsured",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SureInsured_Sures_Idsure",
                table: "SureInsured",
                column: "Idsure",
                principalTable: "Sures",
                principalColumn: "Idsure",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
