using Domain.Model.Cuentas;
using Domain.Repository.Cuentas;
using Infrastructure.EntityFramwork.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramwork.Repository.Cuentas
{
    internal class CuentaRepository : ICuentaRepository
    {
        private readonly WriteDbContext _context;

        public CuentaRepository(WriteDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Cuenta obj)
        {
            await _context.Cuentas.AddAsync(obj);
        }
        public async Task<Cuenta?> FindByIdAsync(Guid id)
        {
            return await _context.Cuentas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(Cuenta obj)
        {
            _context.Cuentas.Remove(obj);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Cuenta obj)
        {
            _context.Cuentas.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
