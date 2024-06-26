﻿using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Categories;

public class DeleteCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapDelete("/{id}", HandlerAsync)
        .WithName("Categories: Delete")
        .WithSummary("Delete a category")
        .WithDescription("Delete a category")
        .WithOrder(3)
        .Produces<ResponseBase<Category?>>();

    private static async Task<IResult> HandlerAsync(
        ClaimsPrincipal user,
        long id,
        ICategoryHandler handler) 
    {
        var request = new DeleteCategoryRequest 
        { 
            Id = id,
            UserId = user.Identity?.Name ?? string.Empty
    };
        
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
