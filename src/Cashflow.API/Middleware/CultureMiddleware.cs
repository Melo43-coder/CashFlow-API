using System.Globalization;

namespace Cashflow.API.Middleware;

public class CultureMiddleware
{
    private readonly RequestDelegate _next;
    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        var culture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

        var culteInfo = new CultureInfo("pt-BR");
        if (string.IsNullOrEmpty(culture) == false)
        {
            culteInfo = new CultureInfo(culture);

        }

        CultureInfo.CurrentCulture = culteInfo;
        CultureInfo.CurrentUICulture = culteInfo;
    }
}
