using CashFlow.Exepction;
using CashFlow.Exepction.ExecptionBase;
using CAshFLow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cashflow.API.Filters;

public class Exepctionfilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
       if(context.Exception is ErrorOnvalidationException)
        {
            HandleProjectExepction(context);
        
        }
        else
        {
            ThrowUnkowError(context);
        }
    }

    private void HandleProjectExepction(ExceptionContext context)
    {
        if(context.Exception is ErrorOnvalidationException)
        {
            var ex = (ErrorOnvalidationException)context.Exception;

            var errorResponse = new ResponseErrorJson(ex. Errors);
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(errorResponse);

        }

        else
        {
            var ErrorResponse = new ResponseErrorJson(context.Exception.Message);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(ErrorResponse);
        }

    }

    private void ThrowUnkowError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson(Resource1.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        context.Result = new ObjectResult(errorResponse);
    }


}
