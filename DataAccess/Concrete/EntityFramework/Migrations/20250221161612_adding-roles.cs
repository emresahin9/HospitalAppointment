using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Concrete.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class addingroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorRole_Doctors_DoctorId",
                table: "DoctorRole");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorRole_Roles_RoleId",
                table: "DoctorRole");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientRole_Patients_PatientId",
                table: "PatientRole");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientRole_Roles_RoleId",
                table: "PatientRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientRole",
                table: "PatientRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorRole",
                table: "DoctorRole");

            migrationBuilder.RenameTable(
                name: "PatientRole",
                newName: "PatientRoles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "DoctorRole",
                newName: "DoctorRoles",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_PatientRole_RoleId",
                schema: "dbo",
                table: "PatientRoles",
                newName: "IX_PatientRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientRole_PatientId",
                schema: "dbo",
                table: "PatientRoles",
                newName: "IX_PatientRoles_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorRole_RoleId",
                schema: "dbo",
                table: "DoctorRoles",
                newName: "IX_DoctorRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorRole_DoctorId",
                schema: "dbo",
                table: "DoctorRoles",
                newName: "IX_DoctorRoles_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientRoles",
                schema: "dbo",
                table: "PatientRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorRoles",
                schema: "dbo",
                table: "DoctorRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorRoles_Doctors_DoctorId",
                schema: "dbo",
                table: "DoctorRoles",
                column: "DoctorId",
                principalSchema: "dbo",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorRoles_Roles_RoleId",
                schema: "dbo",
                table: "DoctorRoles",
                column: "RoleId",
                principalSchema: "dbo",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientRoles_Patients_PatientId",
                schema: "dbo",
                table: "PatientRoles",
                column: "PatientId",
                principalSchema: "dbo",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientRoles_Roles_RoleId",
                schema: "dbo",
                table: "PatientRoles",
                column: "RoleId",
                principalSchema: "dbo",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorRoles_Doctors_DoctorId",
                schema: "dbo",
                table: "DoctorRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorRoles_Roles_RoleId",
                schema: "dbo",
                table: "DoctorRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientRoles_Patients_PatientId",
                schema: "dbo",
                table: "PatientRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientRoles_Roles_RoleId",
                schema: "dbo",
                table: "PatientRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientRoles",
                schema: "dbo",
                table: "PatientRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorRoles",
                schema: "dbo",
                table: "DoctorRoles");

            migrationBuilder.RenameTable(
                name: "PatientRoles",
                schema: "dbo",
                newName: "PatientRole");

            migrationBuilder.RenameTable(
                name: "DoctorRoles",
                schema: "dbo",
                newName: "DoctorRole");

            migrationBuilder.RenameIndex(
                name: "IX_PatientRoles_RoleId",
                table: "PatientRole",
                newName: "IX_PatientRole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientRoles_PatientId",
                table: "PatientRole",
                newName: "IX_PatientRole_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorRoles_RoleId",
                table: "DoctorRole",
                newName: "IX_DoctorRole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorRoles_DoctorId",
                table: "DoctorRole",
                newName: "IX_DoctorRole_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientRole",
                table: "PatientRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorRole",
                table: "DoctorRole",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorRole_Doctors_DoctorId",
                table: "DoctorRole",
                column: "DoctorId",
                principalSchema: "dbo",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorRole_Roles_RoleId",
                table: "DoctorRole",
                column: "RoleId",
                principalSchema: "dbo",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientRole_Patients_PatientId",
                table: "PatientRole",
                column: "PatientId",
                principalSchema: "dbo",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientRole_Roles_RoleId",
                table: "PatientRole",
                column: "RoleId",
                principalSchema: "dbo",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
