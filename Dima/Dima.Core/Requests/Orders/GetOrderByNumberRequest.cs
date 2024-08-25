namespace Dima.Core.Requests.Orders;

public class GetOrderByNumberRequest : RequestBase
{
    public string Number { get; set; } = string.Empty;
}
