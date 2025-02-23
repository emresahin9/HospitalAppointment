using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    internal class PatientRoleConfiguration : IEntityTypeConfiguration<PatientRole>
    {
        public void Configure(EntityTypeBuilder<PatientRole> builder)
        {
            builder.ToTable("PatientRoles", "dbo");
            builder.HasKey(x => x.Id);
        }
    }
}
