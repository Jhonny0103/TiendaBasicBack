using Microsoft.EntityFrameworkCore;
using TiendaBasic.Models;

namespace TiendaBasic.Data
{
    public class TiendaContext : DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> options) 
            : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
