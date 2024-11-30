namespace Dima.Api;

public static class ApiConfiguration
{
    public const string CorsPolicyName = "wasm";
    
    //API KEY armazenada em user-secrets local
    public static string StripeApiKey {  get; set; } = string.Empty;
}
