﻿using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Orders.ValueObjects;
using Optivem.Template.Core.Domain.Products.ValueObjects;

namespace Optivem.Template.Core.Domain.Orders.Entities
{
    public class OrderDetail : Entity<OrderDetailIdentity>
    {
        public OrderDetail(OrderDetailIdentity id, ProductIdentity productId, decimal quantity, decimal unitPrice, OrderDetailStatus status) 
            : base(id)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Status = status;
        }

        public ProductIdentity ProductId { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public OrderDetailStatus Status { get; }
    }
}