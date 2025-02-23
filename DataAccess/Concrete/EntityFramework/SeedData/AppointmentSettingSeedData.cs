using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.SeedData
{
    internal class AppointmentSettingSeedData
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentSetting>().HasData(
               new AppointmentSetting { Id = 1, AppointmentDurationInMinutes = 20, AppointmentStartTimeInHours = 8, AppointmentEndTimeInHours = 17, BreakStartTimeInHours = 12, BreakEndTimeInHours = 13 }
            );
        }
    }
}
