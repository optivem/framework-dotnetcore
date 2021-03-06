﻿using Atomiv.Core.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Atomiv.Web.AspNetCore.ExceptionProblemDetailsFactories
{
    public class AuthorizationExceptionProblemDetailsFactory : BaseExceptionProblemDetailsFactory<AuthorizationException, ProblemDetails>
    {
        private const HttpStatusCode StatusCode = HttpStatusCode.Forbidden;
        private const string ProblemTypeUri = "https://tools.ietf.org/html/rfc7231#section-6.5.3";

        public AuthorizationExceptionProblemDetailsFactory()
            : base(StatusCode, ProblemTypeUri)
        {
        }
    }
}
