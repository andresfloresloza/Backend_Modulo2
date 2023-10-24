using Domain.Model.Usuarios;
using Domain.Repository.Usuarios;
using Infrastructure.EntityFramwork.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramwork.Repository.Usuarios
{
    internal class UsuarioRepository : IUsuarioRepository
    {
        private readonly WriteDbContext _context;

        public UsuarioRepository(WriteDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Usuario obj)
        {
            await _context.Usuarios.AddAsync(obj);
        }
        public async Task<Usuario?> FindByIdAsync(Guid id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Usuario> GetAsync(string email)
        {
            return await _context.Usuarios.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(Usuario obj)
        {
            _context.Usuarios.Remove(obj);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Usuario obj)
        {
            _context.Usuarios.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
