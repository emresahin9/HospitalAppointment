using Core.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.SeedData
{
    internal class RoleSeedData
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
               new Role { Id = 1, Name = "admin" },
               new Role { Id = 2, Name = "doctor" },
               new Role { Id = 3, Name = "patient" }
            );
        }
    }
}
