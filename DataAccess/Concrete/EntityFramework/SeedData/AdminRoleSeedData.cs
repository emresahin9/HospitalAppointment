using Core.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.SeedData
{
    internal class AdminRoleSeedData
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminRole>().HasData(
               new AdminRole { Id = 1, RoleId = 1, AdminId = 1 }
            );
        }
    }
}
