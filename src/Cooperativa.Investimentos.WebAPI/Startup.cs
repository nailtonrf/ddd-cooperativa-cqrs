using Cooperativa.Investimentos.Poupancas;
using Cooperativa.Investimentos.Storer;
using Infraestructure.BusProvider;
using Infraestructure.Core;
using Infraestructure.Core.Data.Repositories;
using Infraestructure.Core.Injector;
using Infraestructure.CrossCutting.Contexts;
using Infraestructure.NativeInjectorProvider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Cooperativa.Investimentos.WebAPI
{
    public class Startup
    {
        public IInjector Injector { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            Injector = new InjectorProvider(services);

            RegisterDependencies(Injector);

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "API de Investimentos - Cooperativa", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Investimentos");
            });

            app.UseMvc();

            app.UseTransactionalContext();
        }

        private static void RegisterDependencies(IInjector injector)
        {
            injector.UseInMemoryBusProvider();

            injector.UseInvestimentosDomain();

            injector
                .AddScoped<IRequestContext, RequestContext>()
                .AddSingleTon<IDateTimeService, DateTimeService>()
                .AddSingleTon<IPoupancaStorer, PoupancaStorer>()
                .AddSingleTon<IEventStorer, EventStorer>();
        }
    }
}