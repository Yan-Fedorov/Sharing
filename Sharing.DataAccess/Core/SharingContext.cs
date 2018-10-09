using System.Data.Entity;

namespace Sharing.DataAccess.Core
{
    public class SharingContext: DbContext
    {
        public SharingContext() : base("SharingDb")
        {
            //SeedData.Initialize(this);
        }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Lessor> Lessors { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Сharacteristic> Characteristic { get; set; }
        public DbSet<RenteredMachine> RenteredMachines { get; set; }
        public MediumAction MediumActions { get; set; }
        public ApplicationMode ApplicationModes { get; set; }
        public MachineType MachineTypes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ConfigFluentApi.ConfigApplicationMode(modelBuilder);
            ConfigFluentApi.ConfigLessor(modelBuilder);
            ConfigFluentApi.ConfigLocation(modelBuilder);
            ConfigFluentApi.ConfigBoughtSong(modelBuilder);
            ConfigFluentApi.ConfigArtist(modelBuilder);
            ConfigFluentApi.ConfigAlbum(modelBuilder);
            ConfigFluentApi.ConfigAddress(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

    }
}
