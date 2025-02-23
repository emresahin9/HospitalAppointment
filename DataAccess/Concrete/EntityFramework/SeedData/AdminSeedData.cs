using Core.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Web.Helpers;

namespace DataAccess.Concrete.EntityFramework.SeedData
{
    internal class AdminSeedData
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(
               new Admin { Id = 1, Email = "admin@admin.com", Name = "Admin", Surname = "Admin", Password = Crypto.Hash("12345678", "MD5") }
            );
        }
    }
}
