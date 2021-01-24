using Microsoft.EntityFrameworkCore;
using PortalDeNoticias.Data;
using PortalDeNoticias.Models;
using PortalDeNoticias.Services.Exceptions;
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

        public async Task InsertAsync(Autor obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Autor> FindByIdAsync(int id)
        {
            return await _context.Autor.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Autor.FindAsync(id);
                _context.Autor.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Autor obj)
        {
            bool hasAny = await _context.Autor.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Autor não encontrado");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
