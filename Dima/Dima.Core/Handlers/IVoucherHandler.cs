﻿using Dima.Core.Models;
using Dima.Core.Requests.Orders;
using Dima.Core.Responses;

namespace Dima.Core.Handlers;

public interface IVoucherHandler
{
    Task<ResponseBase<Voucher?>> GetByNumberAsync(GetVoucherByNumberRequest request);
}
