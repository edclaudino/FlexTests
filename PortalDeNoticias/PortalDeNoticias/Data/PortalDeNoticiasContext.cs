using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortalDeNoticias.Models;

namespace PortalDeNoticias.Data
{
    public class PortalDeNoticiasContext : DbContext
    {
        public PortalDeNoticiasContext (DbContextOptions<PortalDeNoticiasContext> options)
            : base(options)
        {
        }

        public DbSet<Autor> Autor { get; set; }
        public DbSet<Noticia> Noticia { get; set; }
    }
}
