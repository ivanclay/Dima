using Dima.Core.Common.Extensions;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using System.Net.Http.Json;

namespace Dima.Web.Handlers;

public class TransactionHandler(IHttpClientFactory httpClientFactory) : ITransactionHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
    
    public async Task<ResponseBase<Transaction?>> CreateAsync(CreateTransactionRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/trasactions", request);
        return await result.Content.ReadFromJsonAsync<ResponseBase<Transaction?>>()
            ?? new ResponseBase<Transaction?>(null, 400, "Não foi possível criar a transação");
    }

    public async Task<ResponseBase<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/trasactions/{request.Id}", request);
        return await result.Content.ReadFromJsonAsync<ResponseBase<Transaction?>>()
            ?? new ResponseBase<Transaction?>(null, 400, "Não foi possível atualizar a transação");
    }

    public async Task<ResponseBase<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
    {
        var result = await _client.DeleteAsync($"v1/trasactions/{request.Id}");
        return await result.Content.ReadFromJsonAsync<ResponseBase<Transaction?>>()
            ?? new ResponseBase<Transaction?>(null, 400, "Não foi possível excluir a transação");
    }

    public async Task<ResponseBase<Transaction?>> GetByIdAsync(GetByIdTransactionRequest request) => await _client.GetFromJsonAsync<ResponseBase<Transaction?>>($"v1/transactions/{request.Id}")
            ?? new ResponseBase<Transaction?>(null, 400, "Não foi possível obter a transação.");
    public async Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetByPeriodTransactionRequest request)
    {
        const string format = "yyyy-MM-dd";
        var startDate = request.StartDate is not null
            ? request.StartDate.Value.ToString(format)
            : DateTime.Now.GetFirstDay().ToString(format);

        var endDate = request.EndDate is not null
            ? request.EndDate.Value.ToString(format)
            : DateTime.Now.GetLastDay().ToString(format);

        var url = $"v1/transactions?startDate={startDate}&endDate={endDate}";

        return await _client.GetFromJsonAsync<PagedResponse<List<Transaction>?>>(url)
            ?? new PagedResponse<List<Transaction>?>(null, 400, "Não foi possível obter as transações");
    }

}
