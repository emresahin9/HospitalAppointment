using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Concrete.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class seeddataupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "25D55AD283AA400AF464C76D713C07AD");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "12345678");
        }
    }
}
