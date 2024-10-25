using asp_servicios.Controllers;
using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<Conexion, Conexion>();
            // Repositorios
            services.AddScoped<IPaisesRepositorio, PaisesRepositorio>();
            services.AddScoped<IDepartamentosRepositorio, DepartamentosRepositorio>();
            services.AddScoped<ICiudadesRepositorio, CiudadesRepositorio>();
            services.AddScoped<IBarriosRepositorio, BarriosRepositorio>();
            services.AddScoped<IUsuariosRepositorio, UsuariosRepositorio>();
            services.AddScoped<ICoordenadasRepositorio, CoordenadasRepositorio>();
            services.AddScoped<IDetallesRepositorio, DetallesRepositorio>();
            services.AddScoped<IUbicacionesRepositorio, UbicacionesRepositorio>();
            // Aplicaciones
            services.AddScoped<IPaisesAplicacion, PaisesAplicacion>();
            services.AddScoped<IDepartamentosAplicacion, DepartamentosAplicacion>();
            services.AddScoped<ICiudadesAplicacion, CiudadesAplicacion>();
            services.AddScoped<IBarriosAplicacion, BarriosAplicacion>();
            services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>();
            services.AddScoped<ICoordenadasAplicacion, CoordenadasAplicacion>();
            services.AddScoped<IDetallesAplicacion, DetallesAplicacion>();
            services.AddScoped<IUbicacionesAplicacion, UbicacionesAplicacion>();
            // Controladores
            services.AddScoped<TokenController, TokenController>();

            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}