using Connectors.Entities;
using Microsoft.EntityFrameworkCore;

namespace Connectors
{
    public class FirstAppContext : DbContext
    {
        public DbSet<HousingLocation> HousingLocations { get; set; }

        public FirstAppContext(DbContextOptions<FirstAppContext> options) : base(options)
        {
        }
    }
}
