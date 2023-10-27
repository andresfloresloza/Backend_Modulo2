using Domain.Model.Movimientos;
using SharedKernel.Core;

namespace Domain.Repository.Movimientos
{
    public interface IMovimientoRepository : IRepository<Movimiento, Guid>
    {
        Task UpdateAsync(Movimiento obj);
        Task RemoveAsync(Guid id);
    }
}
