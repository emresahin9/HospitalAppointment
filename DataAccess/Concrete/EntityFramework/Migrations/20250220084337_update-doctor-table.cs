using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Concrete.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class updatedoctortable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_MedicalSpecialtys_MedicalSpecialtyId",
                schema: "dbo",
                table: "Doctors");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalSpecialtyId",
                schema: "dbo",
                table: "Doctors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_MedicalSpecialtys_MedicalSpecialtyId",
                schema: "dbo",
                table: "Doctors",
                column: "MedicalSpecialtyId",
                principalSchema: "dbo",
                principalTable: "MedicalSpecialtys",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_MedicalSpecialtys_MedicalSpecialtyId",
                schema: "dbo",
                table: "Doctors");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalSpecialtyId",
                schema: "dbo",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_MedicalSpecialtys_MedicalSpecialtyId",
                schema: "dbo",
                table: "Doctors",
                column: "MedicalSpecialtyId",
                principalSchema: "dbo",
                principalTable: "MedicalSpecialtys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
