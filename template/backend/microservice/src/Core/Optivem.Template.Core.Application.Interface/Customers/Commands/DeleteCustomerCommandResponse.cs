﻿using System;

namespace Optivem.Template.Core.Application.Customers.Commands
{
    public class DeleteCustomerCommandResponse
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}