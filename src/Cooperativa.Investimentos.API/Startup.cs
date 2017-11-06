using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Nancy.Owin;

namespace Cooperativa.Investimentos.API
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOwin(pipeline =>
            {
                pipeline.UseNancy(options =>
                {
                    options.Bootstrapper = new InvestimentoApiBootstrapper(app.ApplicationServices);
                });
            });
        }
    }
}