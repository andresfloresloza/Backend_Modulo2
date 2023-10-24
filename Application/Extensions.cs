using Domain.Factory.Categorias;
using Domain.Factory.Cuentas;
using Domain.Factory.Movimientos;
using Domain.Factory.Usuarios;
using Domain.Model.Usuarios;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class Extensions
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddScoped<IUsuarioFactory, UsuarioFactory>();
            services.AddScoped<ICuentaFactory, CuentaFactory>();
            services.AddScoped<ICategoriaFactory, CategoriaFactory>();
            services.AddScoped<IMovimientoFactory, MovimientoFactory>();
            services.AddScoped<AuthenticationSecurity>();

            return services;
        }
    }
}
