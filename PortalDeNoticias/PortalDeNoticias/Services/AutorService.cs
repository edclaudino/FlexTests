using Microsoft.EntityFrameworkCore;
using PortalDeNoticias.Data;
using PortalDeNoticias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeNoticias.Services
{
    public class AutorService
    {
        private readonly PortalDeNoticiasContext _context;

        public AutorService(PortalDeNoticiasContext context)
        {
            _context = context;
        }

        public async Task<List<Autor>> FindAllAsync()
        {
            return await _context.Autor.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
