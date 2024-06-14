﻿using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;

namespace Dima.Api.Endpoints.Categories;

public class CreateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapPost("/", HandlerAsync)
        .WithName("Categories: Create")
        .WithSummary("Create new category")
        .WithDescription("Create new category")
        .WithOrder(1)
        .Produces<ResponseBase<Category?>>();

    private static async Task<IResult> HandlerAsync(
        ICategoryHandler handler,
        CreateCategoryRequest request) 
    {
        request.UserId = "teste@teste.com";
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}
