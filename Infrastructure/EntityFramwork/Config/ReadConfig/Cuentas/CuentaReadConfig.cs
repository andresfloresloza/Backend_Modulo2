using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Infrastructure.EntityFramwork.ReadModel.Cuentas;

namespace Infrastructure.EntityFramwork.Config.ReadConfig.Cuentas
{
    internal class CuentaReadConfig : IEntityTypeConfiguration<CuentaReadModel>
    {
        public void Configure(EntityTypeBuilder<CuentaReadModel> builder)
        {
            builder.ToTable("Cuenta");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nombre).HasColumnName("nombre");
            builder.Property(x => x.Saldo).HasColumnName("saldo").HasPrecision(20, 2);

            builder.Property(x => x.UsuarioId).HasColumnName("usuarioId");
            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey(x => x.UsuarioId);
        }
    }
}
