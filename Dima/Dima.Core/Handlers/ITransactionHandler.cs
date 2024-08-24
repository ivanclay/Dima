using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Core.Handlers;

public interface ITransactionHandler
{
    Task<ResponseBase<Transaction?>> GetByIdAsync(GetByIdTransactionRequest request);
    Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetByPeriodTransactionRequest request);
    Task<ResponseBase<Transaction?>> CreateAsync(CreateTransactionRequest request);
    Task<ResponseBase<Transaction?>> UpdateAsync(UpdateTransactionRequest request);
    Task<ResponseBase<Transaction?>> DeleteAsync(DeleteTransactionRequest request);
}
