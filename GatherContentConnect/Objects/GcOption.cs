using GatherContentConnect.Interface;
using Newtonsoft.Json;

namespace GatherContentConnect.Objects
{
    public class GcOption : IGcOption
    {
        //Specifies the label.
        [JsonProperty("label")]
        public string Label { get; set; }
        //Specifies if selected or not.
        [JsonProperty("selected")]
        public bool IsSelected { get; set; }
        //Specifies the name of the option.
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
