using Dima.Core.Handlers;
using Dima.Core.Models.Reports;
using Dima.Core.Requests.Reports;
using Dima.Core.Responses;
using System.Net.Http.Json;

namespace Dima.Web.Handlers;

public class ReportHandler(IHttpClientFactory httpClientFactory) : IReportHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<ResponseBase<List<IncomesAndExpenses>?>> GetIncomesAndExpensesReportAsync(
        GetIncomesAndExpensesRequest request)
    {
        return await _client.GetFromJsonAsync<ResponseBase<List<IncomesAndExpenses>?>>($"v1/reports/incomes-expenses")
               ?? new ResponseBase<List<IncomesAndExpenses>?>(null, 400, "Não foi possível obter os dados");
    }

    public async Task<ResponseBase<List<IncomesByCategory>?>> GetIncomesByCategoryReportAsync(
        GetIncomesByCategoryRequest request)
    {
        return await _client.GetFromJsonAsync<ResponseBase<List<IncomesByCategory>?>>($"v1/reports/incomes")
               ?? new ResponseBase<List<IncomesByCategory>?>(null, 400, "Não foi possível obter os dados");
    }

    public async Task<ResponseBase<List<ExpensesByCategory>?>> GetExpensesByCategoryReportAsync(
        GetExpensesByCategoryRequest request)
    {
        return await _client.GetFromJsonAsync<ResponseBase<List<ExpensesByCategory>?>>($"v1/reports/expenses")
               ?? new ResponseBase<List<ExpensesByCategory>?>(null, 400, "Não foi possível obter os dados");
    }

    public async Task<ResponseBase<FinancialSummary?>> GetFinancialSummaryReportAsync(GetFinancialSummaryRequest request)
    {
        return await _client.GetFromJsonAsync<ResponseBase<FinancialSummary?>>($"v1/reports/summary")
               ?? new ResponseBase<FinancialSummary?>(null, 400, "Não foi possível obter os dados");
    }
}
