﻿using Optivem.Framework.Core.Common;
using Optivem.Template.Core.Application.Orders.Responses;

namespace Optivem.Template.Core.Application.Orders.Requests
{
    public class SubmitOrderRequest : IRequest<SubmitOrderResponse>
    {
        public int Id { get; set; }
    }
}