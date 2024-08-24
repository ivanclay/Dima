using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using System.Net.Http.Json;

namespace Dima.Web.Handlers;

public class CategoryHandler(IHttpClientFactory httpClientFactory) : ICategoryHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<ResponseBase<Category?>> CreateAsync(CreateCategoryRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/categories", request);
        return await result.Content.ReadFromJsonAsync<ResponseBase<Category?>>()
            ?? new ResponseBase<Category?>(null, 400, "Falha ao criar uma categoria.");
    }

    public async Task<ResponseBase<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/categories/{request.Id}", request);
        return await result.Content.ReadFromJsonAsync<ResponseBase<Category?>>()
            ?? new ResponseBase<Category?>(null, 400, "Falha ao atualizar a categoria.");
    }

    public async Task<ResponseBase<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        var result = await _client.DeleteAsync($"v1/categories/{request.Id}");
        return await result.Content.ReadFromJsonAsync<ResponseBase<Category?>>()
            ?? new ResponseBase<Category?>(null, 400, "Falha ao excluir a categoria.");
    }

    public async Task<ResponseBase<Category?>> GetByIdAsync(GetByIdCategoryRequest request) 
        => await _client.GetFromJsonAsync<ResponseBase<Category?>>($"v1/categories/{request.Id}")
        ?? new ResponseBase<Category?>(null, 400, "Não foi possível obter a categoria.");

    public async Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoryRequest request) 
        => await _client.GetFromJsonAsync<PagedResponse<List<Category>>>($"v1/categories/")
            ?? new PagedResponse<List<Category>>(null, 400, "Não foi possível obter as categorias.");

}
