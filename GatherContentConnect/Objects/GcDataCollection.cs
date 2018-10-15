using System.Collections.Generic;
using GatherContentConnect.Interface;
using Newtonsoft.Json;

namespace GatherContentConnect.Objects
{
    public class GcDataCollection<T> : IGcDataCollection<T>
    {
        [JsonProperty("data")]
        public ICollection<T> Data { get; set; }
    }
}
