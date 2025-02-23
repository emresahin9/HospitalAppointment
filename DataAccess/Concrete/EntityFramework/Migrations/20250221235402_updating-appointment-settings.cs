using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Concrete.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class updatingappointmentsettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTimeInHoursForAppointments",
                schema: "dbo",
                table: "AppointmentSettings",
                newName: "BreakStartTimeInHours");

            migrationBuilder.RenameColumn(
                name: "EndTimeInHoursForAppointments",
                schema: "dbo",
                table: "AppointmentSettings",
                newName: "BreakEndTimeInHours");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentEndTimeInHours",
                schema: "dbo",
                table: "AppointmentSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentStartTimeInHours",
                schema: "dbo",
                table: "AppointmentSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppointmentSettings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AppointmentEndTimeInHours", "AppointmentStartTimeInHours", "BreakEndTimeInHours", "BreakStartTimeInHours" },
                values: new object[] { 17, 8, 13, 12 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentEndTimeInHours",
                schema: "dbo",
                table: "AppointmentSettings");

            migrationBuilder.DropColumn(
                name: "AppointmentStartTimeInHours",
                schema: "dbo",
                table: "AppointmentSettings");

            migrationBuilder.RenameColumn(
                name: "BreakStartTimeInHours",
                schema: "dbo",
                table: "AppointmentSettings",
                newName: "StartTimeInHoursForAppointments");

            migrationBuilder.RenameColumn(
                name: "BreakEndTimeInHours",
                schema: "dbo",
                table: "AppointmentSettings",
                newName: "EndTimeInHoursForAppointments");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AppointmentSettings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTimeInHoursForAppointments", "StartTimeInHoursForAppointments" },
                values: new object[] { 16, 8 });
        }
    }
}
