using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Requests.Categories;

public class UpdateCategoryRequest : RequestBase
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Invalid Type")]
    [MaxLength(80, ErrorMessage = "Inválid Title: The title must contain 80 characters")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Invalid description")]
    public string Description { get; set; } = string.Empty;
}
