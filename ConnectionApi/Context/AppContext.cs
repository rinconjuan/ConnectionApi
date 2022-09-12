using Microsoft.EntityFrameworkCore;
using ConnectionApi.Modelos;

namespace ConnectionApi.Context
{
    public class AppContext:DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }

        public DbSet<Imagenes> Imagenes { get; set; }
        public DbSet<Acciones> Acciones { get; set; }
        public DbSet<AccionesVariador> AccionesVariador { get; set; }
        public DbSet<VelocidadVariador> VelocidadVariador { get; set; }
        public DbSet<Fuente> Fuente { get; set; }
        public DbSet<Registro> Registro { get; set; }
        public DbSet<Agenda> Agenda { get; set; }




    }
}
