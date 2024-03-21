using Newtonsoft.Json;

namespace ContactList.Core.Models.Response.Users
{
    public class UserInfoResponse
    {
        [JsonProperty("user")]
        public UserModelResponse User { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

    }
}
