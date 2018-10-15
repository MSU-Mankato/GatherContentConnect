using System.Collections.Generic;
using GatherContentConnect.Interface;
using Newtonsoft.Json;

namespace GatherContentConnect.Objects
{
    public class GcTemplate : IGcTemplate
    {
        //Specifies the identification number of the Template.
        [JsonProperty("id")]
        public int Id { get; set; }
        //Specifies the identification number of the project.
        [JsonProperty("project_id")]
        public int ProjectId { get; set; }
        //Specifies the identification number of the creator .
        [JsonProperty("created_by")]
        public int CreatedBy { get; set; }
        //Specifies the identification number of the updater .
        [JsonProperty("updated_by")]
        public int UpdatedBy { get; set; }
        //Specifies the name of the template.
        [JsonProperty("name")]
        public string Name { get; set; }
        //Specifies the description of the template.
        [JsonProperty("description")]
        public string Description { get; set; }
        //Specifies the configuration of the template.
        [JsonProperty("config")]
        public ICollection<GcConfig> Config { get; set; }
        //Specifies the date and time when the tempalte was used.
        [JsonProperty("used_at")]
        public string UsedAt { get; set; }
        //Specifies the date and time the template was created at.
        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }
        //Specifies the date and time the template was updated at.
        [JsonProperty("updated_at")]
        public int UpdatedAt { get; set; }
        //Specifies the item count.
        [JsonProperty("usage")]
        public GcUsage Usage { get; set; }
        
    }
}