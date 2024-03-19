using Newtonsoft.Json;

namespace ContactList.Core.Models.Request.Contacts
{
    public class UpdateContactFirstNameRequest
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
    }
}
