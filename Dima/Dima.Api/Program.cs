var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.MapPost(
    "/v1/trasactions",
    (Request request, Handler handler) 
        => handler.handle(request))
    .WithName("Transactions: Create")
    .WithSummary("Create new transaction")
    .Produces<Response>();

//app.MapPut("/", () => "Hello World!");
//app.MapDelete("/", () => "Hello World!");

app.Run();

//REQUEST
public class Request
{
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int Type { get; set; }
    public decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public string UserId { get; set; } = string.Empty;
}
//RESPONSE
public class Response
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
}
//HANDLER
public class Handler
{
    public Response handle(Request request)
    {
        return new Response
        {
            Id=4,
            Title = request.Title,
        };
    }
}