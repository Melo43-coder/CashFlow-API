using CashFlow.APPLICATION.UseCases.Expenses.Register;
using CashFlow.Exepction;
using CAshFLow.Communication.Enumns;
using CAshFLow.Communication.Requests;
using ComomTest.Requests;
using FluentAssertions;

namespace Validator.Test.Expanses.Register;
public class RegisterExpanseValidator 
{
    [Fact]// entende que seria um teste de unidade que sera realizada somente para algo em especifico
    public void Success()
    {
        //Arrange  => criar instancias de tudo que precisamos 
        var validator = new RegisterExpanseValidation();

        var request = RequestExpasionJsonBuilder.Build();
      

        //Act => ação para testar a instancia
        var result = validator.Validate(request);

 
    //Asserts
    result.IsValid.Should().BeTrue(); // mudança no asserts atraves do NuGet
}
    [Fact]
    public void Error_Title_empty()
    {
        var validator = new RegisterExpanseValidation();
        var request = RequestExpasionJsonBuilder.Build();
        request.tittle = string.Empty;
        
       


        //Act => ação para testar a instancia
        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(Resource1.Title_Require));
    }


    [Fact]

    public void Error_date()
    {
        var validator = new RegisterExpanseValidation();
        var request = RequestExpasionJsonBuilder.Build();

        request.Date = DateTime.UtcNow.AddDays(1);

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(Resource1.Expense));

    }

    [Fact]

    public void Error_Payment()
    {
        var validator = new RegisterExpanseValidation();
        var request = RequestExpasionJsonBuilder.Build();

        request.PaymentType = (PaymentType)700;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();

        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(Resource1.Payment));
    }


    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-2)]
    [InlineData(-3)]
    [InlineData(-4)]

    public void Error_Amount(decimal amount)
    {
        var validator = new RegisterExpanseValidation();

        var request = RequestExpasionJsonBuilder.Build();

        request.Amount = amount;


        var results =  validator.Validate(request);

        results.IsValid.Should().BeFalse();

        results.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(Resource1.The_Amount));
    }
}
