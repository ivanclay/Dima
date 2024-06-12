using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Requests.Categories;

namespace Dima.Api.Endpoints.Categories;

public class CreateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapPost("/", HandlerAsync)
        .WithName("Categories: Create")
        .WithSummary("Create new category")
        .WithDescription("Create new category")
        .WithOrder(1);

    private static async Task<IResult> HandlerAsync(
        ICategoryHandler handler,
        CreateCategoryRequest request) 
    {
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result.Data)
            : TypedResults.BadRequest(result.Data);
    }
}
