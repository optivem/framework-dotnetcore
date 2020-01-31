﻿using System;
using System.Collections.Generic;

namespace Optivem.Atomiv.Template.Core.Application.Customers.Queries
{
    public class BrowseCustomersQueryResponse
    {
        public List<BrowseCustomersRecordResponse> Records { get; set; }

        public int TotalRecords { get; set; }
    }

    public class BrowseCustomersRecordResponse
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}