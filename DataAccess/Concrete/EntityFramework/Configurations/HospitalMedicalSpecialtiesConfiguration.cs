using Entity.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    internal class HospitalMedicalSpecialtiesConfiguration : IEntityTypeConfiguration<HospitalMedicalSpecialties>
    {
        public void Configure(EntityTypeBuilder<HospitalMedicalSpecialties> builder)
        {
            builder.ToTable("HospitalMedicalSpecialtiess", "dbo");
            builder.HasKey(x => x.Id);
        }
    }
}
