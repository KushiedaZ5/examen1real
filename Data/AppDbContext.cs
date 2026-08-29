using Microsoft.EntityFrameworkCore;
using TecnoGasPortal.Models;

namespace TecnoGasPortal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<SolicitudServicio> SolicitudesServicio { get; set; }
    }
}
