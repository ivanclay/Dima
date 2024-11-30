using Dima.Core.Requests.Stripe;
using Dima.Core.Responses;
using Dima.Core.Responses.Stripe;

namespace Dima.Core.Handlers;

public interface IStripeHandler
{
    Task<ResponseBase<string?>> CreateSessionAsync(CreateSessionRequest request);
    Task<ResponseBase<StripeTransactionResponse>> GetTransactionsByOrderNumberAsync(GetTrasactionsByOrderNumberRequest request);
}
