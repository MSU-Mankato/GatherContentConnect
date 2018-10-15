using GatherContentConnect.Interface;
using Newtonsoft.Json;

namespace GatherContentConnect.Objects
{
	public class GcDueDate: IGcDueDate
	{
        //The unique ID used to identify a DueDate
	    [JsonProperty("statusid")]
        public int StatusId { get; set; }
	    //Specifies if the Date has passed
	    [JsonProperty("overdue")]
        public bool IsOverDue { get; set; }

        //The Date and Time when someone/something is due.
	    [JsonProperty("date")]
        public GcDate Date { get; set; }
	}
}

