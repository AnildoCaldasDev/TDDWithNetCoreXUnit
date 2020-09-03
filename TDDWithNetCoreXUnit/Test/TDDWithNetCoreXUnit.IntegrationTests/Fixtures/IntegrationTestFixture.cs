using Microsoft.Extensions.DependencyInjection;
using TddNetCoreDev.Repositorio.BLL;
using TddNetCoreDev.Repositorio.Interfaces;

namespace TDDWithNetCoreXUnit.IntegrationTests.Fixtures
{
    public class IntegrationTestFixture
    {
        public IntegrationTestFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<ICaixa, Caixa>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }

    }
}
