﻿using FluentValidation;
using Optivem.Atomiv.Infrastructure.FluentValidation;
using Optivem.Atomiv.Template.Core.Application.Customers.Queries;
using Optivem.Atomiv.Template.Core.Domain.Customers;

namespace Optivem.Atomiv.Template.Infrastructure.Validation.Customers.Queries
{
    public class ViewCustomerQueryValidator : BaseValidator<ViewCustomerQuery>
    {
        public ViewCustomerQueryValidator(ICustomerReadonlyRepository customerReadonlyRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((query, context, cancellation)
                    => customerReadonlyRepository.ExistsAsync(query.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);
        }
    }
}