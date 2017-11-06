using Nancy;

namespace Cooperativa.Investimentos.API.Modules
{
    public sealed class CheckModule : NancyModule
    {
        public CheckModule()
        {
            Get("/", args => "API Investimentos - Check");
        }
    }
}