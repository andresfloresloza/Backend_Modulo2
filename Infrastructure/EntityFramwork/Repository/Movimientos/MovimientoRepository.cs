using Domain.Model.Cuentas;
using Domain.Model.Movimientos;
using Domain.Repository.Movimientos;
using Infrastructure.EntityFramwork.Context;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Infrastructure.EntityFramwork.Repository.Movimientos
{
    internal class MovimientoRepository : IMovimientoRepository
    {
        private readonly WriteDbContext _context;

        public MovimientoRepository(WriteDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Movimiento obj)
        {
            await _context.AddAsync(obj);
        }

        public async Task RemoveAsync(Guid id)
        {
            var movimiento = _context.Movimientos.Find(id);
            _context.Movimientos.Remove(movimiento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movimiento obj)
        {
            _context.Movimientos.Update(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<Movimiento?> FindByIdAsync(Guid id)
        {
            return await _context.Movimientos.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
