using Microsoft.EntityFrameworkCore;
using Sharing.DataAccess;

namespace Sharing.DataAccessCore.Core
{
    public class SharingContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-LQ4TJA9;Database=SharingDb;Trusted_Connection=True;");
        }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Lessor> Lessors { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<RenteredMachine> RenteredMachines { get; set; }
        public DbSet<MediumAction> MediumActions { get; set; }
        public DbSet<ApplicationMode> ApplicationModes { get; set; }
        public DbSet<MachineType> MachineTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigFluentApi.ConfigApplicationMode(modelBuilder);
            ConfigFluentApi.ConfigLessor(modelBuilder);
            ConfigFluentApi.ConfigLocation(modelBuilder);
            ConfigFluentApi.ConfigMachine(modelBuilder);
            ConfigFluentApi.ConfigRenter(modelBuilder);

            base.OnModelCreating(modelBuilder);
            
        }

    }
}
