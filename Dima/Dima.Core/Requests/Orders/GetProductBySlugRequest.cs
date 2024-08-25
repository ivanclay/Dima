namespace Dima.Core.Requests.Orders;

public class GetProductBySlugRequest : RequestBase
{
    public string Slug { get; set; } = string.Empty;
}
