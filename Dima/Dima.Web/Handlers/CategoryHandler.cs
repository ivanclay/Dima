using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;

namespace Dima.Web.Handlers;

public class CategoryHandler : ICategoryHandler
{
    public Task<ResponseBase<Category?>> CreateAsync(CreateCategoryRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseBase<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoryRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseBase<Category?>> GetByIdAsync(GetByIdCategoryRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseBase<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
        throw new NotImplementedException();
    }
}
