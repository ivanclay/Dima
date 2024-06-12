using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Requests.Categories;

public class DeleteCategoryRequest : RequestBase
{
    public long Id { get; set; }
}
