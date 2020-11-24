using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SuzushiroBackend.Models
{
    public class UserInformationViewModel : JsonMessageModel
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }


        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("telephone")]
        public string Telephone { get; set; }


        [JsonPropertyName("userAvatar")]
        public string UserAvatar { get; set; }
    }
}
