using Domain.Model.Usuarios;
using SharedKernel.Core;

namespace Domain.Repository.Usuarios
{
    public interface IUsuarioRepository : IRepository<Usuario, Guid>
    {
        Task<Usuario> GetAsync(string email);
        Task UpdateAsync(Usuario obj);
        Task RemoveAsync(Usuario obj);
    }
}
