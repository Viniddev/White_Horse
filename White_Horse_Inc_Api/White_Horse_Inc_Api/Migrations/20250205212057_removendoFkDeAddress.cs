using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace White_Horse_Inc_Api.Migrations
{
    /// <inheritdoc />
    public partial class removendoFkDeAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserInformations_AddressId",
                table: "UserInformations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_UserInformations_AddressId",
                table: "UserInformations",
                column: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserInformations_AddressId",
                table: "UserInformations");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserInformations_AddressId",
                table: "UserInformations",
                column: "AddressId",
                unique: true);
        }
    }
}
