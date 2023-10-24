using Domain.Model.Categorias;
using Domain.Repository.Categorias;
using Infrastructure.EntityFramwork.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramwork.Repository.Categorias
{
    internal class CategoriaRepository : ICategoriaRepository
    {
        private readonly WriteDbContext _context;

        public CategoriaRepository(WriteDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Categoria obj)
        {
            await _context.Categorias.AddAsync(obj);
        }
        public async Task<Categoria?> FindByIdAsync(Guid id)
        {
            return await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task RemoveAsync(Categoria obj)
        {
            _context.Categorias.Remove(obj);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Categoria obj)
        {
            _context.Categorias.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
