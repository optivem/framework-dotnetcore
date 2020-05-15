﻿using AutoMapper;
using Optivem.Atomiv.Template.Core.Domain.Orders;
using System;

namespace Optivem.Atomiv.Template.Infrastructure.Commands.Mapping.Common
{
    public class OrderIdentityProfile : Profile
    {
        public OrderIdentityProfile()
        {
            CreateMap<OrderIdentity, Guid>()
                .ConvertUsing(src => src.Value);

            CreateMap<OrderItemIdentity, Guid>()
                .ConvertUsing(src => src.Value);
        }
    }
}