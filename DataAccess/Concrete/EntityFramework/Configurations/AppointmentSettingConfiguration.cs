using Entity.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    internal class AppointmentSettingConfiguration : IEntityTypeConfiguration<AppointmentSetting>
    {
        public void Configure(EntityTypeBuilder<AppointmentSetting> builder)
        {
            builder.ToTable("AppointmentSettings", "dbo");
            builder.HasKey(x => x.Id);
        }
    }
}
