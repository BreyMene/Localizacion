using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

namespace asp_presentacion
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
            // Comunicaciones
            services.AddScoped<IPaisesComunicacion, PaisesComunicacion>();
            services.AddScoped<IDepartamentosComunicacion, DepartamentosComunicacion>();
            services.AddScoped<IRolesComunicacion, RolesComunicacion>();
            services.AddScoped<ICoordenadasComunicacion, CoordenadasComunicacion>();
            // Presentaciones
            services.AddScoped<IPaisesPresentacion, PaisesPresentacion>();
            services.AddScoped<ICoordenadasPresentacion, CoordenadasPresentacion>();
            services.AddScoped<IRolesPresentacion, RolesPresentacion>();
            services.AddScoped<IDepartamentosPresentacion, DepartamentosPresentacion>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}