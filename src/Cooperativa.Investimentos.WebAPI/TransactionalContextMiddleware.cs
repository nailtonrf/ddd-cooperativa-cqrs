using System;
using System.Threading.Tasks;
using Infraestructure.Core.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Cooperativa.Investimentos.WebAPI
{
    public class TransactionalContextMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TransactionalContextMiddleware> _logger;
        private readonly ITransactionalContext _transactionalContext;

        public TransactionalContextMiddleware(RequestDelegate next, ITransactionalContext transactionalContext,
            ILogger<TransactionalContextMiddleware> logger)
        {
            _next = next;
            _transactionalContext = transactionalContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
                _transactionalContext.Commit();

            }
            catch (Exception ex)
            {
                _logger.LogError("RequestError", ex, ex.Message);
                context.Response.StatusCode = 500;
            }
        }
    }

    public static class TransactionalContextMiddlewareExtensions
    {
        public static IApplicationBuilder UseTransactionalContext(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TransactionalContextMiddleware>();
        }
    }
}