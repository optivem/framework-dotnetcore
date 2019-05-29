﻿using Optivem.Core.Application;
using Optivem.Core.Domain;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands;
using Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers;
using Optivem.NorthwindLite.Core.Domain.Entities;
using Optivem.NorthwindLite.Core.Domain.Identities;

namespace Optivem.NorthwindLite.Core.Application.UseCases
{
    public class CreateCustomerUseCase : CreateUseCase<CreateCustomerRequest, CreateCustomerResponse, Customer, CustomerIdentity, int>
    {
        public CreateCustomerUseCase(IRequestMapper requestMapper, IResponseMapper responseMapper, IUnitOfWork unitOfWork, ICrudRepository<Customer, CustomerIdentity> repository)
            : base(requestMapper, responseMapper, unitOfWork, repository)
        {
        }

        // TODO: VC: Check possibiluty of factory, and then it will be internally able to also set the id

        protected override Customer GetAggregateRoot(Customer aggregateRoot, CustomerIdentity identity)
        {
            return new Customer(identity, aggregateRoot.FirstName, aggregateRoot.LastName);
        }
    }
}