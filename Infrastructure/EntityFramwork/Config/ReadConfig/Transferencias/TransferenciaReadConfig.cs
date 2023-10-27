using Infrastructure.EntityFramwork.ReadModel.Movimientos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.EntityFramwork.ReadModel.Transferencias;

namespace Infrastructure.EntityFramwork.Config.ReadConfig.Transferencias
{
    internal class TransferenciaReadConfig : IEntityTypeConfiguration<TransferenciaReadModel>
    {
        public void Configure(EntityTypeBuilder<TransferenciaReadModel> builder)
        {
            builder.ToTable("Transferencia");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Saldo).HasColumnName("saldo").HasPrecision(20, 2);
            builder.Property(x => x.Fecha).HasColumnName("fecha");

            builder.HasOne(c => c.CuentaOrigen).WithMany().HasForeignKey(c => c.CuentaOrigenId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.CuentaOrigenId).HasColumnName("cuentaOrigenId");
            builder.HasOne(c => c.CuentaOrigen).WithMany().HasForeignKey(c => c.CuentaOrigenId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.CuentaDestinoId).HasColumnName("cuentaDestinoId");
            builder.HasOne(c => c.CuentaDestino).WithMany().HasForeignKey(c => c.CuentaDestinoId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.UsuarioId).HasColumnName("usuarioId");
            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey(x => x.UsuarioId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
