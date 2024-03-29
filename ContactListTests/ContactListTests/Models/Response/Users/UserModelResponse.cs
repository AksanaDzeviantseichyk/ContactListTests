﻿using Newtonsoft.Json;

namespace ContactList.Core.Models.Response.Users
{
    public class UserModelResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("__v")]
        public int __V { get; set; }
    }
}
