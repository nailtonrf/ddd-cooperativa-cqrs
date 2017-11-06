using System;
using Cooperativa.Investimentos.Infrastructure;
using Cooperativa.Investimentos.Poupancas;
using Cooperativa.Investimentos.Poupancas.Adapters;
using Cooperativa.Investimentos.Storer;
using Infraestructure.BusProvider;
using Infraestructure.Core;
using Infraestructure.Core.Injector;
using Infraestructure.NancyProvider;

namespace Cooperativa.Investimentos.API
{
    public class InvestimentoApiBootstrapper : APIBootstrapper
    {
        public InvestimentoApiBootstrapper(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        /// <summary>
        /// Registro de todas as dependências do contexto delimitado => Domínio + Infra.
        /// </summary>
        /// <param name="injector"></param>
        protected override void RegisterDependencies(IInjector injector)
        {
            new InMemoryBusProviderBootstrapper().Load(injector);

            new InvestimentosDomainBootstrapper().Load(injector);

            injector
                .Register<IDateTimeService, DateTimeService>(Lifestyle.SingleTon)
                .Register<IPoupancaStorer, PoupancaStorer>(Lifestyle.SingleTon)
                .Register<ILancamentoContaCorrenteAdapter, LancamentoContaCorrenteAdapter>(Lifestyle.SingleTon);
        }
    }
}