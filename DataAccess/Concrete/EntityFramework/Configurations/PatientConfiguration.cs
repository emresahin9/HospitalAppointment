using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    internal class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients", "dbo");
            builder.HasKey(x => x.Id);
        }
    }
}
