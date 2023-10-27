using Application.Dto.Categorias;
using Application.UseCases.Queries.Categorias;
using Application.UseCases.Queries.Cuentas;
using Infrastructure.EntityFramwork.Context;
using Infrastructure.EntityFramwork.ReadModel.Categorias;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
internal class GetCategoriaByIdHandler : IRequestHandler<GetCategoriaByIdQuery, List<CategoriaDto>>
    {
        private readonly DbSet<CategoriaReadModel> categorias;

        public GetCategoriaByIdHandler(ReadDbContext dbContext)
        {
            categorias = dbContext.Categorias;
        }

        public async Task<List<CategoriaDto>> Handle(GetCategoriaByIdQuery request, CancellationToken cancellationToken)
        {
            var categoriasDelUsuario = await categorias.AsNoTracking()
                .Where(x => x.UsuarioId == request.UsuarioId)
                .Select(categoria => new CategoriaDto
                {
                    Id = categoria.Id,
                    UsuarioId = categoria.UsuarioId,
                    Nombre = categoria.Nombre,
                    Tipo = categoria.Tipo
                })
                .ToListAsync();

            return categoriasDelUsuario;
        }
    }
}
