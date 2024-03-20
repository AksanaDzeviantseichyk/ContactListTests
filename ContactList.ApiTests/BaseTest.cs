using Autofac;
using ContactList.Core.Modules;
using Microsoft.Extensions.Configuration;

namespace ContactList.ApiTests
{
    public abstract class BaseTest
    {
        protected static ILifetimeScope Scope;
        static BaseTest()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new ContainerBuilder();
            builder.RegisterModule(new TestDependencyModule(configuration));
            var container = builder.Build();

            Scope = container.BeginLifetimeScope();
        }

    }
}
