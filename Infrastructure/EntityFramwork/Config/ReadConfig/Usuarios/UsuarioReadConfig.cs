using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Infrastructure.EntityFramwork.ReadModel.Usuarios;

namespace Infrastructure.EntityFramwork.Config.ReadConfig.Usuarios
{
    internal class UsuarioReadConfig : IEntityTypeConfiguration<UsuarioReadModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioReadModel> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.UsuarioId);
            builder.Property(x => x.UsuarioId).HasColumnName("usuarioId");
            builder.Property(x => x.FirstName).HasColumnName("firstName");
            builder.Property(x => x.LastName).HasColumnName("lastName");
            builder.Property(x => x.Email).HasColumnName("email");
            builder.Property(x => x.Password).HasColumnName("password");
            builder.Property(x => x.MontoTotal).HasColumnName("montoTotal").HasPrecision(20, 2);

        }
    }
}
