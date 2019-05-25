﻿using Optivem.Test.Xunit;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Web.AspNetCore.Test
{
    public class ExceptionsControllerTest : BaseTestFixture<TestClient>
    {
        public ExceptionsControllerTest(TestClient client)
            : base(client)
        {
        }

        [Fact]
        public async Task TestGetAsyncReturnsInternalServerError()
        {
            var response = await Fixture.Exceptions.GetAsync(500);
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [Fact]
        public async Task TestGetAsyncReturnsBadRequestError()
        {
            var response = await Fixture.Exceptions.GetAsync(400);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}