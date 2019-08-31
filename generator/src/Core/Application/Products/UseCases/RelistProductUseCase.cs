﻿using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Domain;
using Optivem.Generator.Core.Application.Products.Requests;
using Optivem.Generator.Core.Application.Products.Responses;
using Optivem.Generator.Core.Domain.Products.Entities;
using Optivem.Generator.Core.Domain.Products.Repositories;
using Optivem.Generator.Core.Domain.Products.ValueObjects;

namespace Optivem.Generator.Core.Application.Products.UseCases
{
    public class RelistProductUseCase : UpdateAggregateUseCase<IProductRepository, RelistProductRequest, RelistProductResponse, Product, ProductIdentity, int>
    {
        public RelistProductUseCase(IUnitOfWork unitOfWork, IResponseMapper responseMapper) : base(unitOfWork, responseMapper)
        {
        }

        protected override ProductIdentity GetIdentity(int id)
        {
            throw new System.NotImplementedException();
        }

        protected override void Update(Product aggregateRoot, RelistProductRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
