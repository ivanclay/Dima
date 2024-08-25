using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Orders;
using Dima.Core.Responses;
using System.Net.Http.Json;

namespace Dima.Web.Handlers;

public class VoucherHandler(IHttpClientFactory httpClientFactory) : IVoucherHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
    public async Task<ResponseBase<Voucher?>> GetByNumberAsync(GetVoucherByNumberRequest request)
    => await _client.GetFromJsonAsync<ResponseBase<Voucher?>>($"v1/vouchers/{request.Number}")
        ?? new ResponseBase<Voucher?>(null, 400, "Não foi possível obter o voucher");
}
