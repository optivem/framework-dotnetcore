﻿using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Queries.Orders;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB.Records;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.MongoDB.Orders
{
    public class ViewOrderQueryHandler : QueryHandler<ViewOrderQuery, ViewOrderQueryResponse>
    {
        public ViewOrderQueryHandler(DatabaseContext context) : base(context)
        {
        }

        public override async Task<ViewOrderQueryResponse> HandleAsync(ViewOrderQuery query)
        {
            var orderRecordId = query.Id;

            var orderRecord = await Context.Orders
                .Find(e => e.Id == orderRecordId)
                .FirstOrDefaultAsync();

            if (orderRecord == null)
            {
                throw new ExistenceException();
            }

            return GetResponse(orderRecord);
        }

        private ViewOrderQueryResponse GetResponse(OrderRecord record)
        {
            var orderItems = record.OrderItems
                .Select(GetResponse)
                .ToList();

            return new ViewOrderQueryResponse
            {
                Id = record.Id,
                CustomerId = record.CustomerId,
                Status = record.OrderStatusId,
                OrderItems = orderItems,
            };
        }

        private FindOrderItemQueryResponse GetResponse(OrderItemRecord orderItemRecord)
        {
            return new FindOrderItemQueryResponse
            {
                Id = orderItemRecord.Id,
                ProductId = orderItemRecord.ProductId,
                Quantity = orderItemRecord.Quantity,
                UnitPrice = orderItemRecord.UnitPrice,
                Status = orderItemRecord.StatusId,
            };
        }
    }
}
