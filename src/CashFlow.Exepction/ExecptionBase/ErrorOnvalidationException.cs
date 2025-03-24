namespace CashFlow.Exepction.ExecptionBase;
public class ErrorOnvalidationException : CashFlowExepction
{
    public List<string> Errors { get; set; }
    public ErrorOnvalidationException(List<string> errorMessages)
    {
        Errors = errorMessages;
        Console.WriteLine("Os erros sao:" + Errors);
    }

}
