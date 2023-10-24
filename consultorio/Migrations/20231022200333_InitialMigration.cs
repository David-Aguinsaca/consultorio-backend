using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace consultorio.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insureds",
                columns: table => new
                {
                    IdInsured = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insureds", x => x.IdInsured);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Iddocument = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extenextension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idinsured = table.Column<int>(type: "int", nullable: true),
                    IdinsuredNavigationIdInsured = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Iddocument);
                    table.ForeignKey(
                        name: "FK_Documents_Insureds_IdinsuredNavigationIdInsured",
                        column: x => x.IdinsuredNavigationIdInsured,
                        principalTable: "Insureds",
                        principalColumn: "IdInsured",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sures",
                columns: table => new
                {
                    IdSure = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sumassured = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Prima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Idinsured = table.Column<int>(type: "int", nullable: true),
                    IdinsuredNavigationIdInsured = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sures", x => x.IdSure);
                    table.ForeignKey(
                        name: "FK_Sures_Insureds_IdinsuredNavigationIdInsured",
                        column: x => x.IdinsuredNavigationIdInsured,
                        principalTable: "Insureds",
                        principalColumn: "IdInsured",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_IdinsuredNavigationIdInsured",
                table: "Documents",
                column: "IdinsuredNavigationIdInsured");

            migrationBuilder.CreateIndex(
                name: "IX_Sures_IdinsuredNavigationIdInsured",
                table: "Sures",
                column: "IdinsuredNavigationIdInsured");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Sures");

            migrationBuilder.DropTable(
                name: "Insureds");
        }
    }
}
