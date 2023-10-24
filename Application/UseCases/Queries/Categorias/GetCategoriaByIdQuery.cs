using Application.Dto.Categorias;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries.Categorias
{
    public class GetCategoriaByIdQuery : IRequest<List<CategoriaDto>>
    {
        public Guid UsuarioId { get; set; }

    }
}
