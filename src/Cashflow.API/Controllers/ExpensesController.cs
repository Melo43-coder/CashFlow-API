using CashFlow.APPLICATION.UseCases.Expenses.Register;
using CashFlow.Exepction.ExecptionBase;
using CAshFLow.Communication.Requests;
using CAshFLow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Cashflow.API.Controllers;

[Route("api/[controller]")] 
[ApiController]
public class ExpensesController : ControllerBase
{

    [HttpPost]
    public IActionResult Register([FromBody] RequestExpasionJson request)
    {
        var UseCases = new RegisterExpenseUseCase();

        var response = UseCases.Execute(request);

        return Created(string.Empty, response);

    }

}
