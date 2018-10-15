using System;
using GatherContentConnect.Interface;
using Newtonsoft.Json;

namespace GatherContentConnect.Objects
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GatherContentConnect.Interface.IGcDate" />
    public class GcDate : IGcDate
    {
        //The specified Date and Time
        [JsonProperty("date")]
        public DateTime? Date { get; set; }

        //The specified Timezone Type
        [JsonProperty("timezone_type")]
        public int? TimeZoneType { get; set; }

        //The specified Timezone
        [JsonProperty("timezone")]
        public string TimeZone { get; set; }
    }
}
