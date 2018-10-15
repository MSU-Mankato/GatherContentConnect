using GatherContentConnect.Interface;
using Newtonsoft.Json;

namespace GatherContentConnect.Objects
{
    public class GcProject: IGcProject
    {
        //Specifies the identification number of the project.
        [JsonProperty("id")]
        public int Id { get; set; }
        //Specifies the name of the project.
        [JsonProperty("name")]
        public string Name { get; set; }
        //Specifies the type of the project.
        [JsonProperty("type")]
        public string Type { get; set; }
        //Specifies if the example is true or not.
        [JsonProperty("example")]
        public bool Example { get; set; }
        //Specifies the account identification number.
        [JsonProperty("account_id")]
        public int AccountId { get; set; }
        //Specifies the text direction.
        [JsonProperty("text_direction")]
        public string TextDirection { get; set; }
        //Specifies the tags allowed.
        [JsonProperty("allowed_tags")]
        public string AllowedTags { get; set; }
        //Specifies the created at property.
        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }
        //Specifies the updated at property.
        [JsonProperty("updated_at")]
        public int UpdatedAt { get; set; }
        //Specifies if the project is over due.
        [JsonProperty("overdue")]
        public bool IsOverDue { get; set; }
        //Lists the statuses present in each project.
        [JsonProperty("statuses")]
        public GcDataCollection<GcStatus> Statuses { get; set; }
    }
}
