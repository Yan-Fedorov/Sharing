using System.Data.Entity;
using Sharing.DataAccess.Core;

namespace Sharing.DataAccess
{
    public class ConfigFluentApi
    {
        public static void ConfigApplicationMode(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationMode>().Property(p => p.Mode).HasMaxLength(20);
            modelBuilder.Entity<ApplicationMode>().ToTable("ApplicationMode");
        }
        public static void ConfigLessor(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lessor>().Property(p => p.FirstName).HasMaxLength(30);
            modelBuilder.Entity<Lessor>().Property(p => p.LastName).HasMaxLength(30);
            modelBuilder.Entity<Lessor>().Property(p => p.Money).HasPrecision(7,2);
            modelBuilder.Entity<Lessor>().ToTable("Lessor");
        }
        public static void ConfigLocation(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().Property(p => p.City).HasMaxLength(30);
            modelBuilder.Entity<Location>().Property(p => p.Continent).HasMaxLength(30);
            modelBuilder.Entity<Location>().Property(p => p.Country).HasMaxLength(30);
            modelBuilder.Entity<Location>().Property(p => p.House).HasMaxLength(30);
            modelBuilder.Entity<Location>().Property(p => p.Street).HasMaxLength(30);
            modelBuilder.Entity<Location>().ToTable("Location");
        }
    }
}
