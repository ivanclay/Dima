using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Categories;

public class UpdateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapPut("/{id}", HandlerAsync)
        .WithName("Categories: Update")
        .WithSummary("Update a category")
        .WithDescription("Update a category")
        .WithOrder(2)
        .Produces<ResponseBase<Category?>>();

    private static async Task<IResult> HandlerAsync(
        ClaimsPrincipal user,
        long id,
        ICategoryHandler handler,
        UpdateCategoryRequest request) 
    {
        request.UserId = user.Identity?.Name ?? string.Empty;
        request.Id = id;
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
