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
    .Produces<ResponseBase<Category>>();

app.Run();

////REQUEST
//public class Request
//{
//    public string Title { get; set; } = string.Empty;
//    public string Description { get; set; } = string.Empty;
//    //public DateTime CreatedAt { get; set; } = DateTime.Now;
//    //public int Type { get; set; }
//    //public decimal Amount { get; set; }
//    //public long CategoryId { get; set; }
//    //public string UserId { get; set; } = string.Empty;
//}
////RESPONSE
//public class Response
//{
//    public long Id { get; set; }
//    public string Title { get; set; } = string.Empty;
//}
////HANDLER
//public class Handler(AppDbContext context)
//{
//    public Response handle(Request request)
//    {
//        var category = new Category
//        {
//            Title = request.Title,
//            Description = request.Description
//        };
//        context.Categories.Add(category);
//        context.SaveChanges();

//        return new Response
//        {
//            Id=category.Id,
//            Title = category.Title,
//        };
//    }
//}