﻿using Dima.Api.Common.Api;
using Dima.Api.Endpoints.Categories;

namespace Dima.Api.Endpoints;

public static class EndpointBase
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGroup("v1/categories")
            .WithTags("Categories")
            //.RequireAuthorization()
            .MapEndpoint<CreateCategoryEndpoint>()
            .MapEndpoint<UpdateCategoryEndpoint>()
            .MapEndpoint<DeleteCategoryEndpoint>()
            .MapEndpoint<GetAllCategoryEndpoint>()
            .MapEndpoint<GetByIdCategoryEndpoint>()
            ;
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
