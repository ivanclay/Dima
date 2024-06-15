using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Api.Endpoints.Transactions;

public class GetByIdTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapGet("/{id}", HandlerAsync)
        .WithName("Transactions: GetById")
        .WithSummary("Get a transaction by id")
        .WithDescription("Get a transaction by id")
        .WithOrder(4)
        .Produces<ResponseBase<Transaction?>>();

    private static async Task<IResult> HandlerAsync(
        long id,
        ITransactionHandler handler) 
    {
        var request = new GetByIdTransactionRequest
        {
            UserId = "teste@teste.com",
            Id = id

        };

        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
