using ContactList.Core.Clients;
using ContactList.Core.Utils;

namespace ContactList.Core.Providers
{
    public class UsersProvider
    {
        private readonly UsersClient _userClient;
        private readonly UsersGenerator _userGenerator;
        public UsersProvider(UsersClient client,
           UsersGenerator generator)
        {
            _userClient = client;
            _userGenerator = generator;
        }
    }
}
