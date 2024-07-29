using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Web.Handlers;

public class TransactionHandler : ITransactionHandler
{
    public Task<ResponseBase<Transaction?>> CreateAsync(CreateTransactionRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseBase<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseBase<Transaction?>> GetByIdAsync(GetByIdTransactionRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<List<Transaction>>> GetByPeriodAsync(GetByPeriodTransactionRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseBase<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
    {
        throw new NotImplementedException();
    }
}
