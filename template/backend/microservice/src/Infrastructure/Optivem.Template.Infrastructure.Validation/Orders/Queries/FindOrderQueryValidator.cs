﻿using Optivem.Framework.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Orders.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.Validation.Orders.Queries
{
    public class FindOrderQueryValidator : BaseValidator<FindOrderQuery>
    {
        public FindOrderQueryValidator()
        {

        }
    }
}