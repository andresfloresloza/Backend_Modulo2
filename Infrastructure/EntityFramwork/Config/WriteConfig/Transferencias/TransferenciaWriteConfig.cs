using Domain.Model.Movimientos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using SharedKernel.ValueObjects.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Transferencias;

namespace Infrastructure.EntityFramwork.Config.WriteConfig.Transferencias
{
    internal class TransferenciaWriteConfig : IEntityTypeConfiguration<Transferencia>
    {
        public void Configure(EntityTypeBuilder<Transferencia> builder)
        {
            var saldoConverter = new ValueConverter<SaldoValue, decimal>(
                saldoValue => saldoValue.Value,
                decimalValue => new SaldoValue(decimalValue)
            );

            builder.ToTable("Transferencia");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Saldo).HasColumnName("saldo").HasConversion(saldoConverter).HasPrecision(20, 2);
            builder.Property(x => x.Fecha).HasColumnName("fecha");
            builder.Property(x => x.CuentaOrigenId).HasColumnName("cuentaOrigenId");
            builder.Property(x => x.CuentaDestinoId).HasColumnName("cuentaDestinoId"); 
            builder.Property(x => x.UsuarioId).HasColumnName("usuarioId");


            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}