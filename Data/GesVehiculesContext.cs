using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GesVehicules.Entities;

namespace GesVehicules.Data
{
    public class GesVehiculesContext : DbContext
    {
        public GesVehiculesContext (DbContextOptions<GesVehiculesContext> options)
            : base(options)
        {
        }

        public DbSet<GesVehicules.Entities.Vehicule> Vehicule { get; set; } = default!;
    }
}
