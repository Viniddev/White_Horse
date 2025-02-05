using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace White_Horse_Inc_Api.Migrations
{
    /// <inheritdoc />
    public partial class adicionandodemaistabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "CompanyRole",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "CompanyRole",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BIT")
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "CompanyRole",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "CompanyRole",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 0)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Rg = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CompanyRoleId = table.Column<long>(type: "bigint", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInformations_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInformations_CompanyRole_CompanyRoleId",
                        column: x => x.CompanyRoleId,
                        principalTable: "CompanyRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInformations_AddressId",
                table: "UserInformations",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInformations_CompanyRoleId",
                table: "UserInformations",
                column: "CompanyRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInformations");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "CompanyRole",
                type: "DATETIME2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "CompanyRole",
                type: "BIT",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "CompanyRole",
                type: "DATETIME2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "CompanyRole",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Relational:ColumnOrder", 0)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
