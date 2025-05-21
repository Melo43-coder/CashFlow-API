using ClassFlow.Domain.Enums;

namespace ClassFlow.Domain.Entities;
public class Expenses
{
    public long id { get; set; }

    public string tittle { get; set; }

    public string? Description { get; set; }  

    public DateTime Date { get; set; }

    public decimal Amount { get; set; }

    public PaymentType PaymentType { get; set; }


}
