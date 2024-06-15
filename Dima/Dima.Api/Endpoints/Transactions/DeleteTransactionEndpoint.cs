﻿using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Api.Endpoints.Transactions;

public class DeleteTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapDelete("/{id}", HandlerAsync)
        .WithName("Transactions: Delete")
        .WithSummary("Delete a transaction")
        .WithDescription("Delete a transaction")
        .WithOrder(3)
        .Produces<ResponseBase<Transaction?>>();

    private static async Task<IResult> HandlerAsync(
        long id,
        ITransactionHandler handler) 
    {
        var request = new DeleteTransactionRequest 
        { 
            Id = id,
            UserId = "teste@teste.com"
        };
        
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
