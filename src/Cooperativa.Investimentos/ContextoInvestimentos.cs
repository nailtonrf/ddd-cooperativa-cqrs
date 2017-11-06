using Infraestructure.Core.DomainModel;

namespace Cooperativa.Investimentos
{
    public sealed class ContextoInvestimentos : IBoundedContext
    {
        public string Name => "Investimentos";
        public string Description => "Contexto de Investimentos";
    }
}