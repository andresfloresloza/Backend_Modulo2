using Domain.Model.Transferencias;
using Domain.Repository.Transferencias;
using Infrastructure.EntityFramwork.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramwork.Repository.Transferencias
{
    internal class TransferenciaRepository : ITransferenciaRepository
    {
        private readonly WriteDbContext _context;

        public TransferenciaRepository(WriteDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Transferencia obj)
        {
            await _context.AddAsync(obj);
        }

        public async Task<Transferencia?> FindByIdAsync(Guid id)
        {
            return await _context.Transferencias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(Guid id)
        {
            var transferencia = _context.Transferencias.Find(id);
            _context.Transferencias.Remove(transferencia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Transferencia obj)
        {
            _context.Transferencias.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
