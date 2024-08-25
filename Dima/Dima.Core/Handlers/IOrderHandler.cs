using Dima.Core.Models;
using Dima.Core.Requests.Orders;
using Dima.Core.Responses;

namespace Dima.Core.Handlers;

public interface IOrderHandler
{
    Task<ResponseBase<Order?>> CancelAsync(CancelOrderRequest request);
    Task<ResponseBase<Order?>> CreateAsync(CreateOrderRequest request);
    Task<ResponseBase<Order?>> PayAsync(PayOrderRequest request);
    Task<ResponseBase<Order?>> RefundAsync(RefundOrderRequest request);
    Task<PagedResponse<List<Order>?>> GetAllAsync(GetAllOrdersRequest request);
    Task<ResponseBase<Order?>> GetByNumberAsync(GetOrderByNumberRequest request);
}
