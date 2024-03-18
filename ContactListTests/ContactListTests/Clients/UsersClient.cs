using ContactList.Core.HTTP;
using Microsoft.Extensions.Configuration;

namespace ContactList.Core.Clients
{
    public class UsersClient
    {
        private readonly string _url;

        private readonly HtpClientCustom _client;

        public UsersClient(IConfiguration configuration,
            HtpClientCustom client)
        {
            _url = configuration["Url:userService"];
            _client = client;
        }

    }
}
