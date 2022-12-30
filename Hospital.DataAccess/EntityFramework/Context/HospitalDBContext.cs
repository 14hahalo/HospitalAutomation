using Hospital.DataAccess.EntityFramework.Mapping;
using Hospital.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DataAccess.EntityFramework.Context
{
    public class HospitalDBContext : DbContext
    {
        public HospitalDBContext(DbContextOptions<HospitalDBContext> options) : base(options)
        {

        }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdminMapping())
                .ApplyConfiguration(new ManagerMapping())
                .ApplyConfiguration(new PersonnelMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
