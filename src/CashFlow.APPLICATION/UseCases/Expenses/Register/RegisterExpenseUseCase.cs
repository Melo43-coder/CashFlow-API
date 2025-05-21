using CashFlow.Exepction.ExecptionBase;
using CashFlow.Infra.DataAcess;
using CAshFLow.Communication.Enumns;
using CAshFLow.Communication.Requests;
using ClassFlow.Domain.Entities;
using ClassFlow.Domain.Enums;


namespace CashFlow.APPLICATION.UseCases.Expenses.Register;
public class RegisterExpenseUseCase
{
    public RequestExpasionJson Execute(RequestExpasionJson request)
    {
        Validate(request);
        var dbContext = new cashflowDbcontext();
        

        var entity = new ClassFlow.Domain.Entities.Expenses
        {
            Amount = request.Amount,
            Date = request.Date,
            Description = request.Description,
            tittle = request.tittle,
            PaymentType = (ClassFlow.Domain.Enums.PaymentType)request.PaymentType,
        };

        dbContext.expenses.Add(entity);

        dbContext.SaveChanges();
        
        

        return new RequestExpasionJson();


    }

    private void Validate(RequestExpasionJson request)
    {


        var validator = new RegisterExpanseValidation();

        var result = validator.Validate(request);

       

        if (result.IsValid == false) 
        //aqui significa que o resultado validado for falso ou seja se houver algo errado ele entrara nesse IF caso contrario o codigo ficar tranquilo
        {
            var errosMsg = result.Errors.Select(f => f.ErrorMessage).ToList();
            // no caso eu to somente selecionando as msg de erro 
            //LINQ para selecionar mensagens de erro de uma lista de objetos de validação. Estou selecionando cada um dos elementos Erros para serem executados dentro da lista

            throw new ErrorOnvalidationException(errosMsg);
            //throw → é uma palavra-chave usada para lançar (ou disparar) uma exceção.

            //new ArgumentException(); → cria uma nova instância da exceção do tipo ArgumentException.

            //Quando esse código é executado, ele interrompe o fluxo normal do programa e gera um erro do tipo ArgumentException.
            //Isso significa que algo inesperado aconteceu, geralmente relacionado a um argumento inválido passado para um método ou função.
        }
    }
}
