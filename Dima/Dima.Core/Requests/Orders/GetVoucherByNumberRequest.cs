namespace Dima.Core.Requests.Orders;

public class GetVoucherByNumberRequest : RequestBase
{
    public string Number { get; set; } = string.Empty;
}
