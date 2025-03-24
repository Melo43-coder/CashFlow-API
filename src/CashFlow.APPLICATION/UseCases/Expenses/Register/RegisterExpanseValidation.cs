using CAshFLow.Communication.Requests;
using FluentValidation;

namespace CashFlow.APPLICATION.UseCases.Expenses.Register;
public class RegisterExpanseValidation : AbstractValidator<RequestExpasionJson> //dentro deste sinal smepre sera o seu tipo de validação aonde vc quer aplicar
{
    public RegisterExpanseValidation()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage("The Title is required");
        // aqui eu estou criando uma regra para o titulo aonde ele nao pode ser vazio!!

        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("The amount must be greater than zero");
        //aqui eu estou criando a regra de validação do Amount aonde eu consigo 

        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Expenses cannot be for the future");
        //aqui eu estou criando a regra de validação de data aonde precisa se somente no dia nao no futuro ou passado Usando o LessThanOrEqualTo

        RuleFor(expense => expense.paymentType).IsInEnum().WithMessage("Payment type is not valid");
        // aqui estou criando a regra para validar o paymenttype utilizando o IsInEnum para validar os meus enums

    }
}
