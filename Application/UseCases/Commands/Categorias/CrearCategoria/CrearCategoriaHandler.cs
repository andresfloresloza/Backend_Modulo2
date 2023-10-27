using Domain.Factory.Categorias;
using Domain.Repository.Categorias;
using Domain.Repository.Usuarios;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCases.Commands.Categorias.CrearCategoria
{
    public class CrearCategoriaHandler : IRequestHandler<CrearCategoriaCommand, Guid>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICategoriaFactory _categoriaFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearCategoriaHandler(ICategoriaRepository categoriaRepository, IUsuarioRepository usuarioRepository, ICategoriaFactory categoriaFactory, IUnitOfWork unitOfWort)
        {
            _categoriaRepository = categoriaRepository;
            _usuarioRepository = usuarioRepository;
            _categoriaFactory = categoriaFactory;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(CrearCategoriaCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.FindByIdAsync(request.UsuarioId);

            if (usuario == null)
            {
                throw new BussinessRuleValidationException("Usuario no encontrado");
            }

            var categoria = _categoriaFactory.Crear(
                request.UsuarioId,
                request.Nombre,
                request.Tipo
                );

            await _categoriaRepository.CreateAsync(categoria);
            await _unitOfWork.Commit();
            return categoria.Id;
        }
    }
}
