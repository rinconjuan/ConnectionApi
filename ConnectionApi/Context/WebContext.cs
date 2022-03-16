using Microsoft.EntityFrameworkCore;
using ConnectionApi.Modelos;

namespace ConnectionApi.Context
{
    public class WebContext:DbContext
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options)
        {

        }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
