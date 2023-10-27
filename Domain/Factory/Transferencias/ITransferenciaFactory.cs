using Domain.Model.Movimientos;
using Domain.Model.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factory.Transferencias
{
    public interface ITransferenciaFactory
    {
        Transferencia Crear(Guid cuentaOrigenId, Guid cuentaDestinoId, Guid usuarioId, decimal saldo);
    }
}
