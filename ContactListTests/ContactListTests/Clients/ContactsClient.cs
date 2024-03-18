using ContactList.Core.HTTP;
using Microsoft.Extensions.Configuration;

namespace ContactList.Core.Clients
{
    public class ContactsClient
    {
        private readonly string _url;

        private readonly HtpClientCustom _client;

        public ContactsClient(IConfiguration configuration,
            HtpClientCustom client)
        {
            _url = configuration["Url:contactsService"];
            _client = client;
        }
    }
}
