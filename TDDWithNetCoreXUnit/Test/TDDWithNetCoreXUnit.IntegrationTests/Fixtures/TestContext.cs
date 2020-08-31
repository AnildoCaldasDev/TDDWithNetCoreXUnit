﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NetCoreApiDevTDD;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TDDWithNetCoreXUnit.IntegrationTests.Fixtures
{
    public class TestContext
    {
        public HttpClient Client { get; set; }
        private TestServer _server;

        public TestContext()
        {
            SetupClient();
        }

        private void SetupClient()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = _server.CreateClient();
        }

    }

}
