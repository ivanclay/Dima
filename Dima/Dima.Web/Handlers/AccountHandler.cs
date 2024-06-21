using Dima.Core.Handlers;
using Dima.Core.Requests.Account;
using Dima.Core.Responses;
using System.Net.Http.Json;
using System.Text;

namespace Dima.Web.Handlers;

public class AccountHandler(IHttpClientFactory httpClientFactory) : IAccountHandler
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<ResponseBase<string>> LoginAsync(LoginRequest request)
    {
        var result = await _httpClient.PostAsJsonAsync("v1/identity/login?useCookie=true", request);
        return result.IsSuccessStatusCode
            ? new ResponseBase<string>("Login successfully!", 200, "Login successfully!")
            : new ResponseBase<string>(null, 400, "Unable to login");
    }

    public async Task<ResponseBase<string>> RegisterAsync(RegisterRequest request)
    {
        var result = await _httpClient.PostAsJsonAsync("v1/identity/register", request);
        return result.IsSuccessStatusCode
            ? new ResponseBase<string>("Register successfully!", 201, "Register successfully!")
            : new ResponseBase<string>(null, 400, "Unable to register");
    }

    public async Task LogoutAsync()
    {
        var emptyContent = new StringContent("{}", Encoding.UTF8, "application/json");
        await _httpClient.PostAsJsonAsync("v1/identity/logout", emptyContent);
    }

}
