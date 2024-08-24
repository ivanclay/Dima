using Dima.Core.Models.Reports;
using Dima.Core.Requests.Reports;
using Dima.Core.Responses;

namespace Dima.Core.Handlers;

public interface IReportHandler
{
    Task<ResponseBase<List<IncomesAndExpenses>?>> GetIncomesAndExpensesReportAsync(GetIncomesAndExpensesRequest request);
    Task<ResponseBase<List<IncomesByCategory>?>> GetIncomesByCategoryReportAsync(GetIncomesByCategoryRequest request);
    Task<ResponseBase<List<ExpensesByCategory>?>> GetExpensesByCategoryReportAsync(GetExpensesByCategoryRequest request);
    Task<ResponseBase<FinancialSummary?>> GetFinancialSummaryReportAsync(GetFinancialSummaryRequest request);
}
