using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    internal class DoctorRoleConfiguration : IEntityTypeConfiguration<DoctorRole>
    {
        public void Configure(EntityTypeBuilder<DoctorRole> builder)
        {
            builder.ToTable("DoctorRoles", "dbo");
            builder.HasKey(x => x.Id);
        }
    }
}
