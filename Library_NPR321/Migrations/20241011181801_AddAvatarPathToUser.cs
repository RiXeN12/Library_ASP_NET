using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_NPR321.Migrations
{
    /// <inheritdoc />
    public partial class AddAvatarPathToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "73e98618-2b2b-4bc4-95f6-8ea99bf9f420.webp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "c4a53845-cb61-4168-8514-a28e15e27847.jpeg");
        }
    }
}
