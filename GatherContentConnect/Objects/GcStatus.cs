using GatherContentConnect.Interface;
using Newtonsoft.Json;

namespace GatherContentConnect.Objects
{
   public class GcStatus : IGcStatus
    {
        //Specifies the identification number of the status.
        [JsonProperty("id")]
        public string Id { get; set; }
        //Specifies if the status is default or not.
        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }
        //Specifies the position.
        [JsonProperty("position")]
        public string Position { get; set; }
        //Specifies the color.
        [JsonProperty("color")]
        public string Color { get; set; }
        //Specifies the name of the status.
        [JsonProperty("name")]
        public string Name { get; set; }
        //Describes the status in detail.
        [JsonProperty("description")]
        public string Description { get; set; }
        //Specifies if editable or not.
        [JsonProperty("can_edit")]
        public bool CanEdit { get; set; }
    }
}
