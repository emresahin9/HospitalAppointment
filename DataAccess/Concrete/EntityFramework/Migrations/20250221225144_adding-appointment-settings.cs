using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Concrete.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class addingappointmentsettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentSettings",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDurationInMinutes = table.Column<int>(type: "int", nullable: false),
                    StartTimeInHoursForAppointments = table.Column<int>(type: "int", nullable: false),
                    EndTimeInHoursForAppointments = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentSettings", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppointmentSettings",
                columns: new[] { "Id", "AppointmentDurationInMinutes", "EndTimeInHoursForAppointments", "StartTimeInHoursForAppointments" },
                values: new object[] { 1, 20, 16, 8 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentSettings",
                schema: "dbo");
        }
    }
}
