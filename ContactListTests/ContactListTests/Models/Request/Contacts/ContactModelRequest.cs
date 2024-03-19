using Newtonsoft.Json;

namespace ContactList.Core.Models.Request.Contacts
{
    public class ContactModelRequest
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("birthdate")]
        public DateOnly BirthDate { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("street1")]
        public string Street1 { get; set; }

        [JsonProperty("street2")]
        public string Street2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("stateProvince")]
        public string StateProvince { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; } 
    }
}
