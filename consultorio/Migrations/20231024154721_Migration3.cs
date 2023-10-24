using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace consultorio.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Extenextension",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Documents",
                newName: "Name");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "Documents",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Documents",
                newName: "Url");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Extenextension",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
