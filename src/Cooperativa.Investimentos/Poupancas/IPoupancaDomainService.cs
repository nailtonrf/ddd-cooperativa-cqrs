using Infraestructure.Core.Messaging;

namespace Cooperativa.Investimentos.Poupancas
{
    public interface IPoupancaDomainService : ICommandHandler<CriarNovaPoupancaCommand>
    {
    }
}