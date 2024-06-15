using Dima.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Requests.Transactions;

public class UpdateTransactionRequest : RequestBase
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Invalid Title")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Invalid Type")]
    public ETtransactionType Type { get; set; }

    [Required(ErrorMessage = "Invalid amount")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Invalid Category")]
    public long CategoryId { get; set; }

    [Required(ErrorMessage = "Invalid Date")]
    public DateTime PaidOrReceivedAt { get; set; }

}
