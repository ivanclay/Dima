using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Orders;
using Dima.Core.Responses;
using System.Net.Http.Json;

namespace Dima.Web.Handlers;

public class ProductHandler(IHttpClientFactory httpClientFactory) : IProductHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
    public async Task<PagedResponse<List<Product>?>> GetAllAsync(GetAllProductsRequest request)
    =>
        await _client.GetFromJsonAsync<PagedResponse<List<Product>?>>("v1/products")
            ?? new PagedResponse<List<Product>?>(null, 400, "Não foi possível obter os produtos");

    public async Task<ResponseBase<Product?>> GetBySlugAsync(GetProductBySlugRequest request)
    => await _client.GetFromJsonAsync<ResponseBase<Product?>>($"v1/products/{request.Slug}")
        ?? new ResponseBase<Product?>(null, 400, "Não foi possível obter o produto");
}
