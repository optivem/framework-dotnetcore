﻿using Optivem.Atomiv.Core.Application;
using System;

namespace Optivem.Atomiv.Template.Core.Application.Commands.Customers
{
    public class EditCustomerCommand : IRequest<EditCustomerCommandResponse>
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}