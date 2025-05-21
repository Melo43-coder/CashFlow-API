using CAshFLow.Communication.Enumns;

namespace CAshFLow.Communication.Requests;
public class RequestExpasionJson //aqui eu irei realizar uma requisiçãio Post no controller para adicionar o modelo de pagamento da minha API 
{
    public readonly object paymentType;

    public string tittle { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public DateTime Date { get; set; }

    public decimal Amount { get; set; }

    public PaymentType PaymentType { get; set; }


}

