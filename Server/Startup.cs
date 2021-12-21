using Blazored.SessionStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Operacao.Server.Data;
using Operacao.Server.Services;
using System.Linq;

namespace Operacao.Server
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.AllowAnyMethod();
                                      builder.SetIsOriginAllowed((host) => true);
                                      builder.AllowAnyHeader();
                                  });
            });

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDbContext<AppDbContext>(options =>
      options.UseMySql(Configuration.GetConnectionString("AppDbContext"), builder =>
      builder.MigrationsAssembly("Operacao")));

            services.AddScoped<DoadNovoService>();
            services.AddScoped<FuncionarioService>();
            services.AddScoped<AcaoDoadNovoService>();
            services.AddScoped<CriterioDoadNovoService>();
            services.AddScoped<EnderecoService>();
            services.AddScoped<CategoriaService>();
            services.AddScoped<ContribuinteService>();
            services.AddScoped<ContratoService>();
            services.AddScoped<ParcelaService>();
            services.AddScoped<BoletoService>();

            services.AddBlazoredSessionStorage();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });

        }
    }
}
