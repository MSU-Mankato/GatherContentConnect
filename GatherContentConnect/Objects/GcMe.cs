using System.Collections.Generic;
using GatherContentConnect.Interface;
using Newtonsoft.Json;

namespace GatherContentConnect.Objects
{
    public class GcMe : IGcMe
    {
        //Specifies the Email id of the user.
        [JsonProperty("email")]
        public string Email { get; set; }
        //Specifies the first name of the user.
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        //Specifies the last name of the user.
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        //Specifies the time zone.
        [JsonProperty("timezone")]
        public string TimeZone { get; set; }
        //Specifies the Language.
        [JsonProperty("language")]
        public string Language { get; set; }
        //Specifies the Gender.
        [JsonProperty("gender")]
        public string Gender { get; set; }
        //Specifies the Image Url.
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
        //Specifies the announcements collection.
        [JsonProperty("announcements")]
        public ICollection<GcAnnouncements> Announcements { get; set; }
    }
}