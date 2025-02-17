using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.SeedData
{
    internal class HospitalSeedData
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hospital>().HasData(
               new Hospital { Id = 1, Name = "İstanbul Hastanesi", Address = "Egemenlik Caddesi No:34 Şişli / İstanbul" }
            );
        }
    }
}
