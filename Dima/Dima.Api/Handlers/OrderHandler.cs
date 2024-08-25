﻿using Dima.Api.Data;
using Dima.Core.Enums;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Orders;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers;

public class OrderHandler(AppDbContext context, IStripeHandler stripeHandler) : IOrderHandler
{
    public async Task<ResponseBase<Order?>> CancelAsync(CancelOrderRequest request)
    {
        Order? order;
        try
        {
            order = await context
                .Orders
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (order is null)
                return new ResponseBase<Order?>(null, 404, "Pedido não encontrado");
        }
        catch
        {
            return new ResponseBase<Order?>(null, 500, "Falha ao obter pedido");
        }

        switch (order.Status)
        {
            case EOrderStatus.Canceled:
                return new ResponseBase<Order?>(order, 400, "O pedido já foi cancelado!");

            case EOrderStatus.Paid:
                return new ResponseBase<Order?>(order, 400, "Um pedido pago não pode ser cancelado!");

            case EOrderStatus.Refunded:
                return new ResponseBase<Order?>(order, 400, "Um pedido reembolsado não pode ser cancelado");

            case EOrderStatus.WaitingPayment:
                break;

            default:
                return new ResponseBase<Order?>(order, 400, "Pedido com situação inválida!");
        }

        order.Status = EOrderStatus.Canceled;
        order.UpdatedAt = DateTime.Now;

        try
        {
            context.Orders.Update(order);
            await context.SaveChangesAsync();
        }
        catch
        {
            return new ResponseBase<Order?>(order, 500, "Não foi possível atualizar seu pedido");
        }

        return new ResponseBase<Order?>(order, 200, $"Pedido {order.Number} atualizado!");
    }

    public async Task<ResponseBase<Order?>> CreateAsync(CreateOrderRequest request)
    {
        Product? product;
        try
        {
            product = await context
                .Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.ProductId && x.IsActive == true);

            if (product is null)
                return new ResponseBase<Order?>(null, 404, "Produto não encontrado ou inativo");

            context.Attach(product);
        }
        catch
        {
            return new ResponseBase<Order?>(null, 500, "Falha ao verificar produto");
        }

        Voucher? voucher = null;
        try
        {
            if (request.VoucherId is not null)
            {
                voucher = await context
                    .Vouchers
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.VoucherId && x.IsActive == true);

                if (voucher is null)
                    return new ResponseBase<Order?>(null, 404, "Voucher não encontrado ou inativo");

                if (voucher.IsActive == false)
                    return new ResponseBase<Order?>(null, 404, "Este voucher já foi utilizado");

                voucher.IsActive = false;

                // context.Attach(voucher);
                context.Vouchers.Update(voucher);
            }
        }
        catch
        {
            return new ResponseBase<Order?>(null, 500, "Falha ao verificar voucher");
        }

        var order = new Order
        {
            UserId = request.UserId,
            Product = product,
            ProductId = request.ProductId,
            Voucher = voucher,
            VoucherId = request.VoucherId
        };

        try
        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }
        catch
        {
            return new ResponseBase<Order?>(null, 500, "Não foi possível registrar seu pedido");
        }

        return new ResponseBase<Order?>(order, 201, $"Pedido {order.Number} cadastrado com sucesso!");
    }

    public async Task<ResponseBase<Order?>> PayAsync(PayOrderRequest request)
    {
        Console.WriteLine($"Iniciando pagamento do pedido {request.OrderNumber}");
        Order? order;
        try
        {
            order = await context
                .Orders
                .Include(x => x.Product)
                .Include(x => x.Voucher)
                .FirstOrDefaultAsync(x => x.Number == request.OrderNumber && x.UserId == request.UserId);

            if (order is null)
                return new ResponseBase<Order?>(null, 404, $"Pedido {request.OrderNumber} não encontrado");
        }
        catch
        {
            return new ResponseBase<Order?>(null, 500, "Falha ao consultar pedido");
        }

        switch (order.Status)
        {
            case EOrderStatus.Canceled:
                return new ResponseBase<Order?>(order, 400, "O pedido está cancelado!");

            case EOrderStatus.Paid:
                return new ResponseBase<Order?>(order, 400, "O pedido já foi pago");

            case EOrderStatus.Refunded:
                return new ResponseBase<Order?>(order, 400, "Um pedido reembolsado não pode ser cancelado");

            case EOrderStatus.WaitingPayment:
                break;

            default:
                return new ResponseBase<Order?>(order, 400, "Situação do pedido inválida");
        }

        //try
        //{
        //    var getTransactionByOrderNumberRequest = new GetTransactionByOrderNumberRequest
        //    {
        //        Number = order.Number,
        //    };
        //    var result = await stripeHandler.GetTransactionsByOrderNumberAsync(getTransactionByOrderNumberRequest);

        //    if (result.IsSuccess == false)
        //        return new ResponseBase<Order?>(null, 500, "Não foi possível localizar o pagamento do seu pedido!");

        //    if (result.Data is null)
        //        return new ResponseBase<Order?>(null, 500, "Não foi possível localizar o pagamento do seu pedido!");

        //    if (result.Data.Any(item => item.Refunded))
        //        return new ResponseBase<Order?>(null, 500, "Este pedido já foi estornado e não pode ser pago!");

        //    if (!result.Data.Any(item => item.Paid))
        //        return new ResponseBase<Order?>(null, 500, "Este pedido ainda não foi pago!");

        //    request.ExternalReference = result.Data[0].Id;
        //}
        //catch
        //{
        //    return new ResponseBase<Order?>(null, 500, "Não foi possível localizar o pagamento do seu pedido!");
        //}

        order.Status = EOrderStatus.Paid;
        order.ExternalReference = request.ExternalReference;
        order.UpdatedAt = DateTime.Now;

        try
        {
            context.Orders.Update(order);
            await context.SaveChangesAsync();
        }
        catch
        {
            return new ResponseBase<Order?>(order, 500, "Não foi possível realizar o pagamento do seu pedido!");
        }

        return new ResponseBase<Order?>(order, 200, $"Pedido {order.Number} pago com sucesso!");
    }

    public async Task<ResponseBase<Order?>> RefundAsync(RefundOrderRequest request)
    {
        Order? order;
        try
        {
            order = await context
                .Orders
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (order is null)
                return new ResponseBase<Order?>(null, 404, "Pedido não encontrado");
        }
        catch
        {
            return new ResponseBase<Order?>(null, 500, "Falha ao consultar seu pedido");
        }

        switch (order.Status)
        {
            case EOrderStatus.Canceled:
                return new ResponseBase<Order?>(order, 400, "O pedido está cancelado!");

            case EOrderStatus.WaitingPayment:
                return new ResponseBase<Order?>(order, 400, "O pedido ainda não foi pago");

            case EOrderStatus.Refunded:
                return new ResponseBase<Order?>(order, 400, "O pedido já foi reembolsado");

            case EOrderStatus.Paid:
                break;

            default:
                return new ResponseBase<Order?>(order, 400, "Situação do pedido inválida");
        }

        order.Status = EOrderStatus.Refunded;
        order.UpdatedAt = DateTime.Now;

        try
        {
            context.Orders.Update(order);
            await context.SaveChangesAsync();
        }
        catch
        {
            return new ResponseBase<Order?>(order, 500, "Não foi possível reembolsar seu pedido");
        }

        return new ResponseBase<Order?>(order, 200, $"Pedido {order.Number} estornado com sucesso!");
    }

    public async Task<PagedResponse<List<Order>?>> GetAllAsync(GetAllOrdersRequest request)
    {
        try
        {
            var query = context
                .Orders
                .AsNoTracking()
                .Include(x => x.Product)
                .Include(x => x.Voucher)
                .Where(x => x.UserId == request.UserId)
                .OrderBy(x => x.CreatedAt);

            var orders = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<Order>?>(
                orders,
                count,
                request.PageNumber,
                request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Order>?>(null, 500, "Não foi possível consultar os pedidos");
        }
    }

    public async Task<ResponseBase<Order?>> GetByNumberAsync(GetOrderByNumberRequest request)
    {
        try
        {
            var order = await context
                .Orders
                .AsNoTracking()
                .Include(x => x.Product)
                .Include(x => x.Voucher)
                .FirstOrDefaultAsync(x => x.Number == request.Number && x.UserId == request.UserId);

            return order is null
                ? new ResponseBase<Order?>(null, 404, "Pedido não encontrado")
                : new ResponseBase<Order?>(order);
        }
        catch
        {
            return new ResponseBase<Order?>(null, 500, "Não foi possível recuperar o pedido");
        }
    }
}
