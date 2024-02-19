using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployesAdmin.Migrations
{
    /// <inheritdoc />
    public partial class ImageDataEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Employes",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "ImagePublicId",
                table: "Employes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePublicId",
                table: "Employes");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Employes",
                newName: "Image");
        }
    }
}
