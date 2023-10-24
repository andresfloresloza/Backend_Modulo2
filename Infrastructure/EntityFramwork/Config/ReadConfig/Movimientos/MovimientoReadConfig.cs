using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Infrastructure.EntityFramwork.ReadModel.Movimientos;

namespace Infrastructure.EntityFramwork.Config.ReadConfig.Movimientos
{
    internal class MovimientoReadConfig : IEntityTypeConfiguration<MovimientoReadModel>
    {
        public void Configure(EntityTypeBuilder<MovimientoReadModel> builder)
        {
            builder.ToTable("Movimiento");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Descripcion).HasColumnName("descripcion");
            builder.Property(x => x.Tipo).HasColumnName("tipo");
            builder.Property(x => x.Saldo).HasColumnName("saldo").HasPrecision(20, 2);
            builder.Property(x => x.Fecha).HasColumnName("fecha");

            builder.Property(x => x.CuentaId).HasColumnName("cuentaId");
            builder.HasOne(c => c.Cuenta).WithMany().HasForeignKey(c => c.CuentaId).OnDelete(DeleteBehavior.Restrict);


            builder.Property(x => x.CategoriaId).HasColumnName("categoriaId");
            builder.HasOne(x => x.Categoria).WithMany().HasForeignKey(x => x.CategoriaId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
