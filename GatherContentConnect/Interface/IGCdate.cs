using System;

namespace GatherContentConnect.Interface
{
    public interface IGcDate
    {
            //The specified Date and Time
            DateTime? Date { get; set; }

            //The specified Timezone Type
            int? TimeZoneType { get; set; }

            //The specified Timezone
            string TimeZone { get; set; }
     }
}
