using System.Text.Json.Serialization;

namespace Dima.Core.Responses;

public class ResponseBase<TData>
{
    private readonly int _code;

    [JsonConstructor]
    public ResponseBase() => _code = Configuration.DefaultStatusCode;
    
    public ResponseBase(TData? data, int code = Configuration.DefaultStatusCode, string? message = null)
    {
        Data = data;
        Message = message;
        _code = code;
    }
    public TData? Data { get; set; }
    public string? Message { get; set; }

    [JsonIgnore]
    public bool IsSuccess => _code is >= 200 and <= 299; 
}
