using GatherContentConnect.Interface;
using Newtonsoft.Json;

namespace GatherContentConnect.Objects
{
    public class GcAnnouncements : IGcAnnouncements
    {
        //Specifies the announcement id.
        [JsonProperty("id")]
        public string Id { get; set; }
        //Specifies the name of the announcement.
        [JsonProperty("name")]
        public string Name { get; set; }
        //Specifies if the announcement is acknowledged or not.
        [JsonProperty("acknowledged")]
        public bool IsAcknowledged { get; set; }
    }
}