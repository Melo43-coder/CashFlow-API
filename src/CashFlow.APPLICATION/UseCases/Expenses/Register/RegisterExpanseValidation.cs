using CashFlow.Exepction;
using CAshFLow.Communication.Requests;
using FluentValidation;

namespace CashFlow.APPLICATION.UseCases.Expenses.Register;
public class RegisterExpanseValidation : AbstractValidator<RequestExpasionJson> // dentro deste sinal smepre sera o seu tipo de validação aonde vc quer aplicar
{
    public RegisterExpanseValidation()
    {
        RuleFor(expense => expense.tittle).NotEmpty().WithMessage(Resource1.Title_Require);
        // aqui eu estou criando uma regra para o titulo aonde ele nao pode ser vazio!!

        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage(Resource1.The_Amount);
        // aqui eu estou criando a regra de validação do Amount aonde eu consigo nao deixar ser igual a zero 

        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(Resource1.Expense);
        // aqui eu estou criando a regra de validação de data aonde precisa se somente no dia nao no futuro ou passado Usando o LessThanOrEqualTo
        
        RuleFor(expense => expense.paymentType).IsInEnum().WithMessage(Resource1.Payment);
        // aqui estou criando a regra para validar o paymenttype utilizando o IsInEnum para validar os meus enums
    }
}
