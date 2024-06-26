﻿using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Categories;

public class GetByIdCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapGet("/{id}", HandlerAsync)
        .WithName("Categories: GetById")
        .WithSummary("Get a category by id")
        .WithDescription("Get a category by id")
        .WithOrder(4)
        .Produces<ResponseBase<Category?>>();

    private static async Task<IResult> HandlerAsync(
        ClaimsPrincipal user,
        long id,
        ICategoryHandler handler) 
    {
        var request = new GetByIdCategoryRequest
        {
            UserId = user.Identity?.Name ?? string.Empty,
        Id = id

        };

        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
