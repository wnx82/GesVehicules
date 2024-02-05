using GesVehicules.Entities;
using Microsoft.EntityFrameworkCore;
namespace GesVehicules
{
    public class Database : DbContext
    {
        public DbSet<Vehicule> Vehicules { get; set; } = null!;

        public Database(DbContextOptions options) : base(options)
        {

        }
    }
}