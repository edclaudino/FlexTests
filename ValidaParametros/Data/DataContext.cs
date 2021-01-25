using Microsoft.EntityFrameworkCore;
using ValidaParametros.Models;

namespace ValidaParametros.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {          
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}