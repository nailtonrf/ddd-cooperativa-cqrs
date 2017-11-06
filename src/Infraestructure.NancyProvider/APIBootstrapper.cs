using System;
using System.Globalization;
using System.Threading;
using Infraestructure.Core;
using Infraestructure.Core.Injector;
using Infraestructure.Core.Messaging;
using Infraestructure.CrossCutting.Contexts;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Configuration;
using Nancy.TinyIoc;

namespace Infraestructure.NancyProvider
{
    public abstract class APIBootstrapper : DefaultNancyBootstrapper
    {
        protected readonly IServiceProvider ServiceProvider;
        private ILogger _defaultLogger;

        protected APIBootstrapper(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
        }

        public override void Configure(INancyEnvironment environment)
        {
            environment.Tracing(true, true);
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register(ServiceProvider.GetService<ILoggerFactory>());
        }

        protected IInjector GetContainer(TinyIoCContainer container)
        {
            return new InjectorProvider(container);
        }

        protected abstract void RegisterDependencies(IInjector injector);

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            var injectorProvider = GetContainer(container);
            RegisterDependencies(injectorProvider);

            pipelines.AfterRequest += AfterRequest;

            var loggerFactory = container.Resolve<ILoggerFactory>();
            _defaultLogger = loggerFactory.CreateLogger(GetType());

            base.ApplicationStartup(container, pipelines);
        }

        private void AfterRequest(NancyContext context)
        {
            _defaultLogger?.LogInformation("End-request");
        }

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            var injector = new InjectorProvider(container);
            container.Register<IServiceResolver>(injector);

            var dateTimeService = container.Resolve<IDateTimeService>();
            var commandSender = container.Resolve<ICommandSender>();

            var requestContext = new RequestContext(dateTimeService, commandSender);
            RegisterRequestContext(requestContext);
            container.Register<IRequestContext>(requestContext);

            _defaultLogger?.LogInformation($"Begin-request - {requestContext.Id}");
        }

        protected virtual void RegisterRequestContext(IRequestContext requestContext)
        {
        }
    }
}