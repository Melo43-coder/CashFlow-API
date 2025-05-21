using Bogus;
using CAshFLow.Communication.Enumns;
using CAshFLow.Communication.Requests;

namespace ComomTest.Requests;
public class RequestExpasionJsonBuilder
{
    public static RequestExpasionJson Build()
    {

       return new Faker<RequestExpasionJson>()
            .RuleFor(r => r.tittle, faker => faker.Commerce.Product())
            .RuleFor(r => r.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(r => r.Date, faker => faker.Date.Past())
            .RuleFor(r => r.paymentType, faker => faker.PickRandom<PaymentType>()) 
            .RuleFor(r => r.Amount, faker => faker.Random.Decimal(min: 1, max: 1000));
            
    }
   
}