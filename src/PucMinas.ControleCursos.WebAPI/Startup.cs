using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using PucMinas.ControleCursos.WebAPI.Configuration;
using PucMinas.ControleCursos.WebAPI.Models.Interfaces;
using PucMinas.ControleCursos.WebAPI.Repositories;
using PucMinas.ControleCursos.WebAPI.Repositories.Context;
using PucMinas.ControleCursos.WebAPI.Services;
using PucMinas.ControleCursos.WebAPI.Services.Interfaces;

namespace PucMinas.ControleCursos.WebAPI
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
            services.AddDbContext<SqliteContext>(options => options.UseSqlite(Configuration.GetConnectionString("SqliteConnection")));

            // Options para configurações customizadas
            services.AddOptions();
            services.AddResponseCaching();
            services.AddLogging();
            services.AddApiVersioning("api/v{version}");

            services.AddWebApi(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
            });
            services.AddWebApi().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            services.AddMvc(opt =>
            {
                opt.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
            });

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            services.AddTransient<IAluno, AlunoRepository>();
            services.AddTransient<IAlunoService, AlunoService>();
            services.AddSingleton(provider => Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
