using ApiSeriesPersonajes2023.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSeriesPersonajes2023.Data
{
    public class SeriesContext: DbContext
    {
        public SeriesContext(DbContextOptions<SeriesContext> options) : base(options) { }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
    }
}
