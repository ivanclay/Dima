using Dima.Api.Data;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers;

public class CategoryHandler(AppDbContext context) : ICategoryHandler
{
    public async Task<ResponseBase<Category?>> CreateAsync(CreateCategoryRequest request)
    {
        try
        {
            var category = new Category
            {
                UserId = request.UserId,
                Title = request.Title,
                Description = request.Description,
            };

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return new ResponseBase<Category?>(category, 201, "Success created category");
        }
        catch
        {
            return new ResponseBase<Category?>(null, 500, "[ERRCRT000] Unable to create category");
        }
    }
    
    public async Task<ResponseBase<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
        try
        {
            var category = await context
            .Categories
            .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (category is null)
            {
                return new ResponseBase<Category?>(null, 404, "Category not found.");
            }

            category.Title = request.Title;
            category.Description = request.Description;

            context.Categories.Update(category);
            await context.SaveChangesAsync();
            return new ResponseBase<Category?>(category);
        }
        catch
        {
            return new ResponseBase<Category?>(null, 500, "[ERRUPD000] Unable to update category");
        }
    }
    
    public Task<ResponseBase<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseBase<List<Category>>> GetAllAsync(GetAllCategoryRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseBase<Category?>> GetByIdAsync(GetByIdCategoryRequest request)
    {
        throw new NotImplementedException();
    }


}
