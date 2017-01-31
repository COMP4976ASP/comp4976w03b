using System.Data.Entity;
using w03b.Models.Address;

namespace w03b.Data
{
    public class AddressContext : DbContext
    {
        public AddressContext() : base("DefaultConnection") { }
        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }
    }
}