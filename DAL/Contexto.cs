using Microsoft.EntityFrameworkCore;
using Registro_Prestamo.Entidades;

namespace Registro_Prestamo.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Moras> Moras { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source=DATA\BDPrestamos.db");
        }
    }
}
