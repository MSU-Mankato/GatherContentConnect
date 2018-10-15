using System.Collections.Generic;
using GatherContentConnect.Interface;
using Newtonsoft.Json;

namespace GatherContentConnect.Objects
{
    public class GcConfig : IGcConfig
    {
        //Specifies the label of the configuration.
        [JsonProperty("label")]
        public string Label { get; set; }
        //Specifies the name.
        [JsonProperty("name")]
        public string Name { get; set; }
        //Specifies if the configuration is hidden or not.
        [JsonProperty("hidden")]
        public bool IsHidden { get; set; }
        //Specifies the set of elements.
        [JsonProperty("elements")]
        public ICollection<GcElement> Elements { get; set; }
    }
}
