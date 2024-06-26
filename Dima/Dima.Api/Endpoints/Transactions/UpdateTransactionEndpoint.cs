﻿using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Transactions;

public class UpdateTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapPut("/{id}", HandlerAsync)
        .WithName("Transactions: Update")
        .WithSummary("Update a transaction")
        .WithDescription("Update a transaction")
        .WithOrder(2)
        .Produces<ResponseBase<Transaction?>>();

    private static async Task<IResult> HandlerAsync(
        ClaimsPrincipal user,
        long id,
        ITransactionHandler handler,
        UpdateTransactionRequest request) 
    {
        request.UserId = user.Identity?.Name ?? string.Empty;
        request.Id = id;
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
