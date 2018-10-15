using GatherContentConnect.Interface;
using Newtonsoft.Json;

namespace GatherContentConnect.Objects
{
    public class GcAccount : IGcAccount
    {

        //Specifies the identification number of the account.
        [JsonProperty("id")]
        public string Id { get; set; }
        //Specifies the name of the account.
        [JsonProperty("name")]
        public string Name { get; set; }
        //Specifies the slug property.
        [JsonProperty("slug")]
        public string Slug { get; set; }
        //Specifies the time zone.
        [JsonProperty("timezone")]
        public string TimeZone { get; set; }
    }
}
