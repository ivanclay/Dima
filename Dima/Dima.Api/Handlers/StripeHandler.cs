using Dima.Core;
using Dima.Core.Handlers;
using Dima.Core.Requests.Stripe;
using Dima.Core.Responses;
using Dima.Core.Responses.Stripe;

using Stripe;
using Stripe.Checkout;

namespace Dima.Api.Handlers;

public class StripeHandler : IStripeHandler
{
    public async Task<ResponseBase<string?>> CreateSessionAsync(CreateSessionRequest request)
    {
        var options = new SessionCreateOptions
        {
            CustomerEmail = request.UserId,
            PaymentIntentData = new SessionPaymentIntentDataOptions
            {
                Metadata = new Dictionary<string, string>
                {
                    {"order", request.OrderNumber }
                }
            },
            PaymentMethodTypes =
            [
                "card"
            ],
            LineItems =
            [
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "BRL",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = request.ProductTitle,
                            Description = request.ProductDescription,
                        },
                        UnitAmount = request.OrderTotal
                    },
                    Quantity = 1
                }
            ],
            Mode = "payment",
            SuccessUrl = $"{Configuration.FrontendUrl}/pedidos/{request.OrderNumber}/confirmar",
            CancelUrl = $"{Configuration.FrontendUrl}/pedidos/{request.OrderNumber}/cancelar"
        };

        var service = new SessionService();
        var session = await service.CreateAsync(options);

        return new ResponseBase<string?>(session.Id);

    }

    public async Task<ResponseBase<StripeTransactionResponse>> GetTransactionsByOrderNumberAsync(GetTrasactionsByOrderNumberRequest request)
    {
        throw new NotImplementedException();
    }
}
