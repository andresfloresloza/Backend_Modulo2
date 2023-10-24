using Application.Dto.Cuentas;
using Application.Dto.Usuarios;
using Application.UseCases.Queries.Usuarios;
using Infrastructure.EntityFramwork.Context;
using Infrastructure.EntityFramwork.ReadModel.Usuarios;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
    internal class GetUsuarioByIdHandler : IRequestHandler<GetUsuarioByIdQuery, List<UsuarioDto>>
    {
        private readonly DbSet<UsuarioReadModel> usuarios;

        public GetUsuarioByIdHandler(ReadDbContext dbContext)
        {
            usuarios = dbContext.Usuarios;
        }

        public async Task<List<UsuarioDto>> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            var infoUsuario = await usuarios.AsNoTracking()
                .Where(x => x.UsuarioId == request.UsuarioId)
                .Select(usuario => new UsuarioDto
                {
                    UsuarioId = usuario.UsuarioId,
                    FirstName = usuario.FirstName,
                    LastName = usuario.LastName,
                    Email = usuario.Email,
                    MontoTotal = usuario.MontoTotal
                })
                .ToListAsync();

            return infoUsuario;
        }
    }
}
