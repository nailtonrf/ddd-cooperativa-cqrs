using Cooperativa.Investimentos.Poupancas;
using Infraestructure.Core.Injector;
using Infraestructure.Core.Messaging;

namespace Cooperativa.Investimentos
{
    public static class InvestimentosBootstrapperExtensions
    {
        public static void UseInvestimentosDomain(this IInjector injector)
        {
            injector
                .AddTransient(typeof(ICommandHandler<CriarNovaPoupancaCommand>), typeof(PoupancaDomainService));
        }
    }
}