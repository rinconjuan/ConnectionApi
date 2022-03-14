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
    }
}
