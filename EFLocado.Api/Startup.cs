using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFLocado.Api.Servicos;
using EFLocado.Domain.Contratos;
using EFLocado.Domain.Contratos.Servicos;
using EFLocado.Infra.Contexto;
using EFLocado.Infra.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace EFLocado.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            /*services.AddDbContext<DataContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("ConexaoPadrao")));*/

            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));



            services.AddControllers().AddNewtonsoftJson();

            services.AddMvc().AddNewtonsoftJson(opt => opt.SerializerSettings.
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IFilmeRepositorio, FilmeRepositorio>();
            services.AddScoped<ILocacaoRepositorio, LocacaoRepositorio>();
            services.AddScoped<IClienteServico, ClienteServico>();
            services.AddScoped<IFilmeServico, FilmeServico>();
            services.AddScoped<ILocacaoServico, LocacaoServico>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Locadora", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Locadora V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
