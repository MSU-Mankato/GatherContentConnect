using GatherContentConnect.Interface;
using Newtonsoft.Json;

namespace GatherContentConnect.Objects
{
    public class GcDataObject<T> : IGcDataObject<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
