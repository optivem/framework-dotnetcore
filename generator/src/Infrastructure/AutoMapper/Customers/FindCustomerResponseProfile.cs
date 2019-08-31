﻿using AutoMapper;
using Optivem.Framework.Infrastructure.AutoMapper;
using Optivem.Generator.Core.Application.Customers.Responses;
using Optivem.Generator.Core.Domain.Customers.Entities;

namespace Optivem.Generator.Infrastructure.AutoMapper.Customers
{
    public class FindCustomerResponseProfile : ResponseProfile<Customer, FindCustomerResponse>
    {
        protected override void Extend(IMappingExpression<Customer, FindCustomerResponse> map)
        {
            // TODO: VC: Separate mappings just for ids
            map.ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id.Id));
        }
    }
}