using Cooperativa.Investimentos.Poupancas;
using Infraestructure.CrossCutting.Contexts;
using Nancy;
using Nancy.ModelBinding;

namespace Cooperativa.Investimentos.API.Modules
{
    public sealed class PoupancaModule : NancyModule
    {
        public PoupancaModule(IRequestContext requestContext)
        {
            ModulePath = "poupanca";

            Get("/", args => "Módulo Poupança.");

            Post("/", args => 
            {
                var novaPoupancaRequisicao = this.Bind<Contracts.CriarNovaPoupancaRequest>();

                var criarNovaPoupancaCommand = new CriarNovaPoupancaCommand(
                    new ContaCorrenteValor(novaPoupancaRequisicao.CooperativaId,
                        novaPoupancaRequisicao.PostoAtendimentoId, novaPoupancaRequisicao.ContaCorrenteId,
                        novaPoupancaRequisicao.Numero, novaPoupancaRequisicao.Digito), novaPoupancaRequisicao.Valor);

                requestContext.Send(criarNovaPoupancaCommand);

                return $"Comando {criarNovaPoupancaCommand.Id}";
            });
        }
    }
}