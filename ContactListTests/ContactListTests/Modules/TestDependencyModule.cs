using Autofac;
using ContactList.Core.Clients;
using ContactList.Core.HTTP;
using ContactList.Core.Providers;
using ContactList.Core.Utils;
using Microsoft.Extensions.Configuration;

namespace ContactList.Core.Modules
{
    public class TestDependencyModule : Module
    {
        private readonly IConfiguration _configuration;

        public TestDependencyModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            var httpClient = new HttpClient();

            builder
                .RegisterInstance(httpClient)
                .As<HttpClient>();

            builder
                .RegisterInstance(_configuration)
                .As<IConfiguration>();

            builder
                .RegisterType<HtpClientCustom>()
                .SingleInstance()
            .AsSelf();

            builder
                .RegisterType<UsersClient>()
                .SingleInstance()
                .AsSelf();

            builder
                .RegisterType<ContactsClient>()
                .SingleInstance()
                .AsSelf();

            builder
                .RegisterType<UsersProvider>()
                .SingleInstance()
                .AsSelf();

            builder
                .RegisterType<ContactsProvider>()
                .SingleInstance()
                .AsSelf();

            builder
                .RegisterType<UsersGenerator>()
                .SingleInstance()
                .AsSelf();

            builder
                .RegisterType<ContactsGenerator>()
                .SingleInstance()
                .AsSelf();
        }
    }
}
