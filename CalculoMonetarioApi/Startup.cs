using CalculoMonetarioApi.Filtros;
using CalculoMonetarioApi.Infraestrutura.Repositorios;
using CaulculoMonetarioApi.Negocio.Interfaces;
using CaulculoMonetarioApi.Negocio.Servicos;
using CaulculoMonetarioApi.Negocio.Servicos.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CalculoMonetarioApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore(options => options.Filters.Add(typeof(ExceptionHandlerFilterAttribute))).AddApiExplorer();
            
            services.AddCors(options =>
            {
                options.AddPolicy("MyCors", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins("https://localhost:44395/taxaJuros", "https://api.github.com");
                       
                });
            });

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Calculo Juros Service Api", Version = "V1" });
            });


            #region Injeção de dependência
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IJurosRepositorio, JurosRepositorio>();
            services.AddScoped<ICalculaJurosServico, CalculaJurosServico>();
            services.AddScoped(typeof(IRequestRepositorio<>), typeof(RequestRepositorio<>));
            services.AddScoped<IConsumindoApiGitHubRepositorio, ConsumindoApiGitHubRepositorio>();
            services.AddScoped<IConsumindoApiGitHubServico, ConsumindoApiGitHubServico>();


            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var supportedCultures = new[]
            {
               "pt-BR"
            };
            
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);

            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "post API V1");
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => options.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .AllowAnyOrigin()
             );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
