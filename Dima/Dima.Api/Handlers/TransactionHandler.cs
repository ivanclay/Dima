using Dima.Api.Data;
using Dima.Core.Common.Extensions;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers;

public class TransactionHandler(AppDbContext context) : ITransactionHandler
{
    public async Task<ResponseBase<Transaction?>> CreateAsync(CreateTransactionRequest request)
    {
        try
        {
            var transaction = new Transaction 
            {
                UserId = request.UserId,
                CategoryId = request.CategoryId,
                CreatedAt = DateTime.UtcNow,
                Amount = request.Amount,
                PaidOrReceivedAt = request.PaidOrReceivedAt,
                Title = request.Title,
                Type = request.Type
            };

            await context.Transactions.AddAsync(transaction);
            await context.SaveChangesAsync();

            return new ResponseBase<Transaction?>(transaction, 201, "Success created transaction");
        }
        catch
        {
            return new ResponseBase<Transaction?>(null, 500, "[ERRCRT001] Unable to create transaction");
        }
    }

    public async Task<ResponseBase<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
    {
        try
        {
            var transaction = await context
                .Transactions
                .FirstOrDefaultAsync(t => t.Id == request.Id && t.UserId == request.UserId);

            if (transaction is null)
                return new ResponseBase<Transaction?>(transaction, 404, "Transaction not found");

            transaction.CategoryId = request.CategoryId;
            transaction.Title = request.Title;
            transaction.Amount = request.Amount;
            transaction.PaidOrReceivedAt = request.PaidOrReceivedAt;
            transaction.Type = request.Type;
        
            context.Transactions.Update(transaction);
            await context.SaveChangesAsync();

            return new ResponseBase<Transaction?>(transaction);

        }
        catch
        {
            return new ResponseBase<Transaction?>(null, 500, "[ERRUPD001] Unable to update transaction");
        }
    }

    public async Task<ResponseBase<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
    {
        try
        {
            var transaction = await context
                .Transactions
                .FirstOrDefaultAsync(t => t.Id == request.Id && t.UserId == request.UserId);

            if (transaction is null)
                return new ResponseBase<Transaction?>(transaction, 404, "Transaction not found");

            context.Transactions.Remove(transaction);
            await context.SaveChangesAsync();

            return new ResponseBase<Transaction?>(transaction);

        }
        catch
        {
            return new ResponseBase<Transaction?>(null, 500, "[ERRUPD001] Unable to remove transaction");
        }
    }

    public async Task<ResponseBase<Transaction?>> GetByIdAsync(GetByIdTransactionRequest request)
    {
        try
        {
            var transaction = await context
            .Transactions
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            return transaction is null
                ? new ResponseBase<Transaction?>(null, 404, "Transaction not found")
                : new ResponseBase<Transaction?>(transaction);
        }
        catch
        {
            return new ResponseBase<Transaction?>(null, 500, "[ERRGET001] Unable to retrieve transaction");
        }
    }

    public async Task<PagedResponse<List<Transaction>>> GetByPeriodAsync(GetByPeriodTransactionRequest request)
    {
        try
        {
            request.StartDate ??= DateTime.Now.GetFirstDay();
            request.EndDate ??= DateTime.Now.GetLastDay();
        }
        catch
        {
            return new PagedResponse<List<Transaction>>(null, 500, "[ERRGET001] Unable to retrieve date start or date end");
        }

        try
        {
            var query = context
                .Transactions
                .AsNoTracking()
                .Where(t => 
                        t.CreatedAt >= request.StartDate &&
                        t.CreatedAt <= request.EndDate && 
                        t.UserId == request.UserId)
                .OrderBy(t => t.CreatedAt);

            var transactions = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<Transaction>>(transactions, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Transaction>>(null, 500, "[ERRGET001] Unable to retrieve transactions");
        }
    }


}
