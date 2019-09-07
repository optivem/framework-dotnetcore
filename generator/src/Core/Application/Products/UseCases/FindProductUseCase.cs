﻿using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mappers;
using Optivem.Framework.Core.Domain;
using Optivem.Generator.Core.Application.Products.Requests;
using Optivem.Generator.Core.Application.Products.Responses;
using Optivem.Generator.Core.Domain.Products;

namespace Optivem.Generator.Core.Application.Products.UseCases
{
    public class FindProductUseCase : FindAggregateUseCase<IProductRepository, FindProductRequest, FindProductResponse, Product, ProductIdentity, int>
    {
        public FindProductUseCase(IUseCaseMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }
    }
}
