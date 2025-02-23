using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Concrete.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class addingpatienttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                schema: "dbo",
                table: "Appointments",
                newName: "Time");

            migrationBuilder.AddColumn<int>(
                name: "DurationInMinutes",
                schema: "dbo",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                schema: "dbo",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DoctorRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorRole_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "dbo",
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientRole_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "doctor" },
                    { 3, "patient" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                schema: "dbo",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorRole_DoctorId",
                table: "DoctorRole",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorRole_RoleId",
                table: "DoctorRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRole_PatientId",
                table: "PatientRole",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRole_RoleId",
                table: "PatientRole",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                schema: "dbo",
                table: "Appointments",
                column: "PatientId",
                principalSchema: "dbo",
                principalTable: "Patients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                schema: "dbo",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "DoctorRole");

            migrationBuilder.DropTable(
                name: "PatientRole");

            migrationBuilder.DropTable(
                name: "Patients",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PatientId",
                schema: "dbo",
                table: "Appointments");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "DurationInMinutes",
                schema: "dbo",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PatientId",
                schema: "dbo",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "Time",
                schema: "dbo",
                table: "Appointments",
                newName: "DateTime");
        }
    }
}
