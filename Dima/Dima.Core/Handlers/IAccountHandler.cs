using Dima.Core.Requests.Account;
using Dima.Core.Responses;

namespace Dima.Core.Handlers;

public interface IAccountHandler
{
    Task<ResponseBase<string>> LoginAsync(LoginRequest request);
    Task<ResponseBase<string>> RegisterAsync(RegisterRequest request);
    Task LogoutAsync();
}
