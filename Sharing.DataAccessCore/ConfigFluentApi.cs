
using Microsoft.EntityFrameworkCore;
using Sharing.DataAccessCore.Core;

namespace Sharing.DataAccessCore
{
    public class ConfigFluentApi
    {
        public static void ConfigApplicationMode(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationMode>().Property(p => p.Mode).HasMaxLength(20);
        }
        public static void ConfigLessor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lessor>().Property(p => p.FirstName).HasMaxLength(30);
            modelBuilder.Entity<Lessor>().Property(p => p.LastName).HasMaxLength(30);
        }
        public static void ConfigLocation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().Property(p => p.City).HasMaxLength(30);
            modelBuilder.Entity<Location>().Property(p => p.Continent).HasMaxLength(30);
            modelBuilder.Entity<Location>().Property(p => p.Country).HasMaxLength(30);
            modelBuilder.Entity<Location>().Property(p => p.House).HasMaxLength(30);
            modelBuilder.Entity<Location>().Property(p => p.Street).HasMaxLength(30);
        }
        public static void ConfigRenter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(p => p.FirstName).HasMaxLength(30);
            modelBuilder.Entity<Customer>().Property(p => p.LastName).HasMaxLength(30);
        }
        public static void ConfigMachine(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CloudResource>().Property(p => p.Name).HasMaxLength(30);
        }
    }
}
