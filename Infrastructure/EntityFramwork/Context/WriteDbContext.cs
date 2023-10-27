using Domain.Model.Categorias;
using Domain.Model.Cuentas;
using Domain.Model.Movimientos;
using Domain.Model.Transferencias;
using Domain.Model.Usuarios;
using Infrastructure.EntityFramwork.Config.WriteConfig.Categorias;
using Infrastructure.EntityFramwork.Config.WriteConfig.Cuentas;
using Infrastructure.EntityFramwork.Config.WriteConfig.Movimientos;
using Infrastructure.EntityFramwork.Config.WriteConfig.Transferencias;
using Infrastructure.EntityFramwork.Config.WriteConfig.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramwork.Context
{
    internal class WriteDbContext : DbContext
    {
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Movimiento> Movimientos { get; set; }
        public virtual DbSet<Transferencia> Transferencias { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioWriteConfig());
            modelBuilder.ApplyConfiguration<Cuenta>(new CuentaWriteConfig());
            modelBuilder.ApplyConfiguration<Categoria>(new CategoriaWriteConfig());
            modelBuilder.ApplyConfiguration<Movimiento>(new MovimientoWriteConfig());
            modelBuilder.ApplyConfiguration<Transferencia>(new TransferenciaWriteConfig());
        }
    }
}
