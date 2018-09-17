using Cooperativa.Investimentos.Poupancas;
using Cooperativa.Investimentos.Usuarios;
using Infraestructure.Core.Injector;
using Infraestructure.Core.Messaging;

namespace Cooperativa.Investimentos
{
    public static class InvestimentosBootstrapperExtensions
    {
        public static void UseInvestimentosDomain(this IInjector injector)
        {
            //Acessando domínio por comando
            injector.AddTransient(typeof(ICommandHandler<CriarNovaPoupancaCommand>), typeof(PoupancaDomainService));

            //Acessando domínio por serviço de domínio
            injector.AddTransient<IUsuariosDomainService, UsuariosDomainService>();
        }
    }
}