using System.Collections.Generic;
using GatherContentConnect.Interface;
using Newtonsoft.Json;

namespace GatherContentConnect.Objects
{
    public class GcItem : IGcItem
    {
        //Specifies the identification number of the item.
        [JsonProperty("id")]
        public int Id { get; set; }
        //Specifies the identification number of the project.
        [JsonProperty("project_id")]
        public int ProjectId { get; set; }
        //Specifies the identification number of the parent.
        [JsonProperty("parent_id")]
        public int ParentId { get; set; }
        //Specifies the identification number of the template.
        [JsonProperty("template_id")]
        public int? TemplateId { get; set; }
        //Specifies the identification number of the custom state.
        [JsonProperty("custom_state_id")]
        public int CustomStateId { get; set; }
        //Specifies the position.
        [JsonProperty("position")]
        public string Position { get; set; }
        //Specifies the name of the item.
        [JsonProperty("name")]
        public string Name { get; set; }
        //Specifies the configuration of the item.
        [JsonProperty("config")]
        public ICollection<GcConfig> Config { get; set; }
        //Specifies the notes.
        [JsonProperty("notes")]
        public string Notes { get; set; }
        //Specifies the type of the item.
        [JsonProperty("type")]
        public string Type { get; set; }
        //Specifies if the item is over due or not.
        [JsonProperty("overdue")]
        public bool IsOverDue { get; set; }
        //Specifies the identification number of the person who archived it.
        [JsonProperty("archived_by")]
        public int? ArchivedBy { get; set; }
        //Specifies the date and time the item was archived at.
        [JsonProperty("archived_at")]
        public GcDate ArchivedAt { get; set; }
        //Specifies the date and time the item was created at.
        [JsonProperty("created_at")]
        public GcDate CreatedAt { get; set; }
        //Specifies the date and time the item was updated at.
        [JsonProperty("updated_at")]
        public GcDate UpdatedAt { get; set; }
        //Specifies the current status.
        [JsonProperty("status")]
        public GcDataObject<GcStatus> CurrentStatus { get; set; }
        //Specifies the due dates of all the items.
        [JsonProperty("due_dates")]
        public GcDataCollection<GcDueDate> DueDates { get; set; }
    }
}
