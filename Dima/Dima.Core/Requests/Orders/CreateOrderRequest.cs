namespace Dima.Core.Requests.Orders;

public class CreateOrderRequest : RequestBase
{
    public long ProductId { get; set; }
    public long? VoucherId { get; set; }
}
