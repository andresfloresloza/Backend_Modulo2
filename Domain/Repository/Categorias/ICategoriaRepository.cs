using Domain.Model.Categorias;
using SharedKernel.Core;

namespace Domain.Repository.Categorias
{
    public interface ICategoriaRepository : IRepository<Categoria, Guid>
    {
        Task UpdateAsync(Categoria obj);
        Task RemoveAsync(Categoria obj);
    }
}
