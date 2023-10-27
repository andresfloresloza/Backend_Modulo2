using Domain.Model.Transferencias;
using SharedKernel.Core;

namespace Domain.Repository.Transferencias
{
    public interface ITransferenciaRepository : IRepository<Transferencia, Guid>
    {
        Task UpdateAsync(Transferencia obj);
        Task RemoveAsync(Guid id);
    }
}
