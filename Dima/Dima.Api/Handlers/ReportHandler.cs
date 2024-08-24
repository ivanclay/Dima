using Dima.Api.Data;
using Dima.Core.Enums;
using Dima.Core.Handlers;
using Dima.Core.Models.Reports;
using Dima.Core.Requests.Reports;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers;

public class ReportHandler(AppDbContext context) : IReportHandler
{
    public async Task<ResponseBase<List<IncomesAndExpenses>?>> GetIncomesAndExpensesReportAsync(
        GetIncomesAndExpensesRequest request)
    {
        await Task.Delay(1280);
        try
        {
            var data = await context
                .IncomesAndExpenses
                .AsNoTracking()
                .Where(x => x.UserId == request.UserId)
                .OrderByDescending(x => x.Year)
                .ThenBy(x => x.Month)
                .ToListAsync();

            return new ResponseBase<List<IncomesAndExpenses>?>(data);
        }
        catch
        {
            return new ResponseBase<List<IncomesAndExpenses>?>(null, 500, "Não foi possível obter as entradas e saídas");
        }
    }

    public async Task<ResponseBase<List<IncomesByCategory>?>> GetIncomesByCategoryReportAsync(
        GetIncomesByCategoryRequest request)
    {
        await Task.Delay(2180);
        try
        {
            var data = await context
                .IncomesByCategories
                .AsNoTracking()
                .Where(x => x.UserId == request.UserId)
                .OrderByDescending(x => x.Year)
                .ThenBy(x => x.Category)
                .ToListAsync();

            return new ResponseBase<List<IncomesByCategory>?>(data);
        }
        catch
        {
            return new ResponseBase<List<IncomesByCategory>?>(null, 500,
                "Não foi possível obter as entradas por categoria");
        }
    }

    public async Task<ResponseBase<List<ExpensesByCategory>?>> GetExpensesByCategoryReportAsync(
        GetExpensesByCategoryRequest request)
    {
        await Task.Delay(812);
        try
        {
            var data = await context
                .ExpensesByCategories
                .AsNoTracking()
                .Where(x => x.UserId == request.UserId)
                .OrderByDescending(x => x.Year)
                .ThenBy(x => x.Category)
                .ToListAsync();

            return new ResponseBase<List<ExpensesByCategory>?>(data);
        }
        catch
        {
            return new ResponseBase<List<ExpensesByCategory>?>(null, 500,
                "Não foi possível obter as entradas por categoria");
        }
    }

    public async Task<ResponseBase<FinancialSummary?>> GetFinancialSummaryReportAsync(GetFinancialSummaryRequest request)
    {
        await Task.Delay(3280);
        var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        try
        {
            var data = await context
                .Transactions
                .AsNoTracking()
                .Where(
                    x => x.UserId == request.UserId
                         && x.PaidOrReceivedAt >= startDate
                         && x.PaidOrReceivedAt <= DateTime.Now
                )
                .GroupBy(x => 1)
                .Select(x => new FinancialSummary(
                    request.UserId,
                    x.Where(ty => ty.Type == ETransactionType.Deposit).Sum(t => t.Amount),
                    x.Where(ty => ty.Type == ETransactionType.Withdraw).Sum(t => t.Amount))
                )
                .FirstOrDefaultAsync();

            return new ResponseBase<FinancialSummary?>(data);
        }
        catch
        {
            return new ResponseBase<FinancialSummary?>(null, 500,
                "Não foi possível obter o resultado financeiro");
        }
    }
}
