using Dima.Api.Data;
using Dima.Api.Handlers;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var cnnStr = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>(
    x =>
    {
        x.UseSqlServer(cnnStr);
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => 
{
    x.CustomSchemaIds(n => n.FullName);
});

builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost(
    "/v1/categories",
    (CreateCategoryRequest request, ICategoryHandler handler) 
        => handler.CreateAsync(request))
    .WithName("Categories: Create")
    .WithSummary("Create new category")
    .Produces<ResponseBase<Category?>>();

app.MapPut(
    "/v1/categories/{id}",
    async (long id, UpdateCategoryRequest request, ICategoryHandler handler)
        => {
            request.Id = id;
            return await handler.UpdateAsync(request);
        })
    .WithName("Categories: Update")
    .WithSummary("Update category")
    .Produces<ResponseBase<Category?>>();

app.MapDelete(
    "/v1/categories/{id}",
    async (long id, ICategoryHandler handler)
        => {
            var request  = new DeleteCategoryRequest
            { 
                Id = id
            };
            return await handler.DeleteAsync(request);
        })
    .WithName("Categories: Delete")
    .WithSummary("Delete category")
    .Produces<ResponseBase<Category?>>();

app.MapGet(
    "/v1/categories",
    async (ICategoryHandler handler)
        => {
            var request = new GetAllCategoryRequest
            {
                UserId = "teste@teste.com"
            };
            return await handler.GetAllAsync(request);
        })
    .WithName("Categories: GetAll")
    .WithSummary("Get all categories by userid")
    .Produces<PagedResponse<List<Category>?>>();

app.MapGet(
    "/v1/categories/{id}",
    async (long id, ICategoryHandler handler)
        => {
            var request = new GetByIdCategoryRequest
            {
                Id = id
            };
            return await handler.GetByIdAsync(request);
        })
    .WithName("Categories: GetById")
    .WithSummary("Get category by id")
    .Produces<ResponseBase<Category?>>();

app.Run();