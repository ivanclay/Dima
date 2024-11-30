namespace Dima.Core.Requests.Stripe;

public class GetTrasactionsByOrderNumberRequest: RequestBase
{
    public string Number { get; set; } = string.Empty;
}
