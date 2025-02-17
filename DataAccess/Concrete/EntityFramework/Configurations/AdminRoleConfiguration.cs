using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    internal class AdminRoleConfiguration : IEntityTypeConfiguration<AdminRole>
    {
        public void Configure(EntityTypeBuilder<AdminRole> builder)
        {
            builder.ToTable("AdminRoles", "dbo");
            builder.HasKey(x => x.Id);
        }
    }
}
