using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;

namespace Dima.Core.Handlers;

public interface ICategoryHandler
{
    Task<ResponseBase<Category?>> GetByIdAsync(GetByIdCategoryRequest request);
    Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoryRequest request);
    Task<ResponseBase<Category?>> CreateAsync(CreateCategoryRequest request);
    Task<ResponseBase<Category?>> UpdateAsync(UpdateCategoryRequest request);
    Task<ResponseBase<Category?>> DeleteAsync(DeleteCategoryRequest request);
}
