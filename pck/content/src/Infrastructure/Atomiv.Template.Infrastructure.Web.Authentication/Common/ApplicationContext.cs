﻿using Atomiv.Template.Core.Application.Context;

namespace Atomiv.Template.Infrastructure.Web.Authentication.Common
{
    public class ApplicationContext : IApplicationContext
    {
        public ApplicationContext()
        {
        }

        // TODO: VC: Configuration, to illustrate application level settings

        public bool IsPromotionDay
        {
            get
            {
                return false;
            }
        }
    }
}
