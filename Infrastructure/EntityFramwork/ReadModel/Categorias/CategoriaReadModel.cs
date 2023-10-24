using Infrastructure.EntityFramwork.ReadModel.Usuarios;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EntityFramwork.ReadModel.Categorias
{
    internal class CategoriaReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public UsuarioReadModel Usuario { get; set; }
        public Guid UsuarioId { get; set; }
        public string Nombre { get; set; }
    }
}
