using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Api.Endpoints.Transactions;

public class CreateTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapPost("/", HandlerAsync)
        .WithName("Transactions: Create")
        .WithSummary("Create new transaction")
        .WithDescription("Create new transaction")
        .WithOrder(1)
        .Produces<ResponseBase<Transaction?>>();

    private static async Task<IResult> HandlerAsync(
        ITransactionHandler handler,
        CreateTransactionRequest request) 
    {
        request.UserId = "teste@teste.com";
        var result = await handler.CreateAsync(request);

        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}
