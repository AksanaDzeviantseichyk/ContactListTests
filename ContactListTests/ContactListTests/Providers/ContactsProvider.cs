using ContactList.Core.Clients;
using ContactList.Core.Utils;

namespace ContactList.Core.Providers
{
    public class ContactsProvider
    {
        private readonly ContactsClient _contactClient;
        private readonly ContactsGenerator _contactGenerator;
        public ContactsProvider(ContactsClient client,
           ContactsGenerator generator)
        {
            _contactClient = client;
            _contactGenerator = generator;
        }
    }
}
