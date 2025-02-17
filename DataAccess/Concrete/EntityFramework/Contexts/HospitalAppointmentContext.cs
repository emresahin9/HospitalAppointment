using Core.Entity.Concrete;
using DataAccess.Concrete.EntityFramework.Configurations;
using DataAccess.Concrete.EntityFramework.SeedData;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class HospitalAppointmentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HospitalAppointmentDatabase;Trusted_Connection=True");
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AdminRole> AdminRoles { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<MedicalSpecialty> MedicalSpecialties { get; set; }
        public DbSet<HospitalMedicalSpecialties> HospitalMedicalSpecialties { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new AdminRoleConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalConfiguration());
            modelBuilder.ApplyConfiguration(new MedicalSpecialtyConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalMedicalSpecialtiesConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());

            new AdminSeedData().Seed(modelBuilder);
            new RoleSeedData().Seed(modelBuilder);
            new AdminRoleSeedData().Seed(modelBuilder);
            new HospitalSeedData().Seed(modelBuilder);
        }
    }
}
