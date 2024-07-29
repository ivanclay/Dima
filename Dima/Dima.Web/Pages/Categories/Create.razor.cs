using Dima.Core.Handlers;
using Dima.Core.Requests.Categories;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Categories;

public partial class CreateCategoryPage : ComponentBase
{
    #region PROPERTIES
    public bool IsBuzy { get; set; } = false;
    public CreateCategoryRequest InputModel { get; set; } = new();
    #endregion

    #region SERVICES

    [Inject]
    public ICategoryHandler Handler { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; }

    #endregion

    #region METHODS
    public async Task OnValidSubmitAsync()
    {
        IsBuzy = true;
        try
        {
            var result = await Handler.CreateAsync(InputModel);
            if (result.IsSuccess)
            {
                NavigationManager.NavigateTo("/categorias");
            }
            else
            {
                Snackbar.Add(result.Message, Severity.Error);
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBuzy = false;
        }
    }
    #endregion

}
