using Newtonsoft.Json;

namespace ContactList.Core.Models.Response
{
    public class UserInfoResponse
    {
        [JsonProperty("user")]
        public UserModel User { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

    }
}
