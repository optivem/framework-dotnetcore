﻿using AutoMapper;
using Optivem.Infrastructure.AutoMapper;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Infrastructure.AutoMapper.Customers
{
    public class UpdateCustomerResponseProfile : ResponseProfile<Customer, UpdateCustomerResponse>
    {
        protected override void Extend(IMappingExpression<Customer, UpdateCustomerResponse> map)
        {
            // TODO: VC: Separate mappings just for ids
            map.ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id.Id));
        }
    }
}