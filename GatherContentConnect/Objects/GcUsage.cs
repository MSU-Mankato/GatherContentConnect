using GatherContentConnect.Interface;
using Newtonsoft.Json;

namespace GatherContentConnect.Objects
{
    public class GcUsage : IGcUsage
    {
        //Specifies the item count number.
        [JsonProperty("item_count")]
        public int ItemCount { get; set; }
    }
}
