using Microsoft.EntityFrameworkCore;
using FBTarjeta.Models;
using static FBTarjeta.Models.Data.TarjetaCredito;

namespace FBTarjeta.Models.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }
        public DbSet<TarjetaCredito> TarjetaCredito { get; set; }

    }
}
