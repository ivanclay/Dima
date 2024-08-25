using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Orders;
using Dima.Core.Responses;
using System.Net.Http.Json;

namespace Dima.Web.Handlers;

public class OrderHandler(IHttpClientFactory httpClientFactory) : IOrderHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
    public async Task<ResponseBase<Order?>> CancelAsync(CancelOrderRequest request)
    {
        var result = await _client.PostAsJsonAsync($"v1/orders/{request.Id}/cancel", request);
        return await result.Content.ReadFromJsonAsync<ResponseBase<Order?>>()
            ?? new ResponseBase<Order?>(null, 400, "Não foi posível cancelar o pedido");
    }

    public async Task<ResponseBase<Order?>> CreateAsync(CreateOrderRequest request)
    {
        var result = await _client.PostAsJsonAsync($"v1/orders", request);
        return await result.Content.ReadFromJsonAsync<ResponseBase<Order?>>()
            ?? new ResponseBase<Order?>(null, 400, "Não foi posível criar o pedido");
    }

    public async Task<ResponseBase<Order?>> PayAsync(PayOrderRequest request)
    {
        var result = await _client.PostAsJsonAsync($"v1/orders/{request.OrderNumber}/pay", request);
        return await result.Content.ReadFromJsonAsync<ResponseBase<Order?>>()
            ?? new ResponseBase<Order?>(null, 400, "Não foi posível pagar o pedido");
    }

    public async Task<ResponseBase<Order?>> RefundAsync(RefundOrderRequest request)
    {
        var result = await _client.PostAsJsonAsync($"v1/orders/{request.Id}/refund", request);
        return await result.Content.ReadFromJsonAsync<ResponseBase<Order?>>()
            ?? new ResponseBase<Order?>(null, 400, "Não foi posível estornar o pedido");
    }

    public async Task<PagedResponse<List<Order>?>> GetAllAsync(GetAllOrdersRequest request)
    => await _client.GetFromJsonAsync<PagedResponse<List<Order>?>>("v1/orders")
        ?? new PagedResponse<List<Order>?>(null, 400, "não foi possível obter os pedidos");

    public async Task<ResponseBase<Order?>> GetByNumberAsync(GetOrderByNumberRequest request)
    => await _client.GetFromJsonAsync<ResponseBase<Order?>>($"v1/orders/{request.Number}")
        ?? new ResponseBase<Order?>(null, 400, "não foi possível obter o pedido");



}
