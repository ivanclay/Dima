using Dima.Api.Data;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Orders;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers;

public class VoucherHandler(AppDbContext context) : IVoucherHandler
{
    public async Task<ResponseBase<Voucher?>> GetByNumberAsync(GetVoucherByNumberRequest request)
    {
        try
        {
            var voucher = await context
                .Vouchers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Number == request.Number && x.IsActive == true);

            return voucher is null
                ? new ResponseBase<Voucher?>(null, 404, "Voucher não encontrado")
                : new ResponseBase<Voucher?>(voucher);
        }
        catch
        {
            return new ResponseBase<Voucher?>(null, 500, "Não foi possível recuperar o voucher");
        }
    }
}
