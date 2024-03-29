﻿using Newtonsoft.Json;

namespace ContactList.Core.Models.Request.Users
{
    public class LoginRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}