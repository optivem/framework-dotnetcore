﻿using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;

namespace Optivem.Template.Core.Domain.Orders
{
    public class OrderFactory
    {
        // TODO: VC: Consider IClock to be injected

        public static Order CreateNewOrder(CustomerIdentity customerId, IEnumerable<OrderItem> orderDetails)
        {
            return new Order(OrderIdentity.Null, customerId, DateTime.Now, OrderStatus.New, orderDetails);
        }

        public static OrderItem CreateNewOrderDetail(Product product, decimal quantity)
        {
            if (product == null)
            {
                throw new ArgumentException();
            }

            if (quantity < 0)
            {
                throw new ArgumentException();
            }

            // TODO: VC: Need to get the product price from repository, perhaps need customer mapper... or do it in the use case?
            // perhaps to be able to write a custom mapper...
            return new OrderItem(OrderItemIdentity.New, product.Id, quantity, product.ListPrice, OrderItemStatus.Allocated);
        }
    }
}