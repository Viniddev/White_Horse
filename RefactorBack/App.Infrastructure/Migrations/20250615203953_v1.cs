using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cep = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false),
                    Street = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Neighborhood = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    City = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Number = table.Column<int>(type: "INT", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInformations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    Rg = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false),
                    UserRole = table.Column<byte>(type: "TINYINT", nullable: false),
                    UserAddressId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInformations_UserAddress_UserAddressId",
                        column: x => x.UserAddressId,
                        principalTable: "UserAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInformations_UserAddressId",
                table: "UserInformations",
                column: "UserAddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInformations");

            migrationBuilder.DropTable(
                name: "UserAddress");
        }
    }
}
