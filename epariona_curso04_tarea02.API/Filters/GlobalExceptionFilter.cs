using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace epariona_curso04_tarea02.API.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    private readonly ILogger<GlobalExceptionFilter> _logger;

    public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "Excepción no controlada.");

        var errorResponse = new
        {
            Message = "Ha ocurrido un error interno en el servidor.",
            Details = context.Exception.Message // En producción esto debería ocultarse
        };

        context.Result = new ObjectResult(errorResponse)
        {
            StatusCode = 500
        };

        context.ExceptionHandled = true;
    }
}
