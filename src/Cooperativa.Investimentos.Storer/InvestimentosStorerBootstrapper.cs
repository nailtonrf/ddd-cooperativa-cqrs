using Cooperativa.Investimentos.Poupancas;
using Cooperativa.Investimentos.Usuarios;
using Infraestructure.Core.Data;
using Infraestructure.Core.Injector;

namespace Cooperativa.Investimentos.Storer
{
    public static class InvestimentosStorerBootstrapper
    {
        public static void UseInvestimentosStorer(this IInjector injector)
        {
            injector.AddScoped<ISessionContext, InvestimentoDbContext>();
            injector.AddTransient<IPoupancaStorer, PoupancaStorer>();
            injector.AddTransient<IUsuarioStorer, UsuarioStorer>();
        }
    }
}