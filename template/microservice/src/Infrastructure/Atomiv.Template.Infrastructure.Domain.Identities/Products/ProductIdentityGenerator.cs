﻿using Atomiv.Infrastructure.SequentialGuid;
using Atomiv.Template.Core.Domain.Products;
using System;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.IdentityGenerators
{
    public class ProductIdentityGenerator : GuidIdentityGenerator<ProductIdentity>
    {
        protected override ProductIdentity Create(Guid value)
        {
            return new ProductIdentity(value);
        }
    }
}
