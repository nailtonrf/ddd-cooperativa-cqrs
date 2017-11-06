using Cooperativa.Investimentos.Poupancas;
using Infraestructure.Core.Bootstrapper;
using Infraestructure.Core.Injector;
using Infraestructure.Core.Messaging;

namespace Cooperativa.Investimentos
{
    public class InvestimentosDomainBootstrapper : IBootstrapper
    {
        /// <summary>
        /// Registra as dependências do domínio.
        /// </summary>
        /// <param name="injector"></param>
        public void Load(IInjector injector)
        {
            injector
                .Register(typeof(ICommandHandler<CriarNovaPoupancaCommand>), typeof(PoupancaDomainService));
        }
    }
}