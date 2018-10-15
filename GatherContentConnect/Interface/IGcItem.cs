using System.Collections.Generic;
using GatherContentConnect.Objects;

namespace GatherContentConnect.Interface
{
    public interface IGcItem
    {
        //Specifies the identification number of the item.
        int Id { get; set; }
        //Specifies the identification number of the project.
        int ProjectId { get; set; }
        //Specifies the identification number of the parent.
        int ParentId { get; set; }
        //Specifies the identification number of the template.
        int? TemplateId { get; set; }
        //Specifies the identification number of the custom state.
        int CustomStateId { get; set; }
        //Specifies the position.
        string Position { get; set; }
        //Specifies the name of the item.
        string Name { get; set; }
        //Specifies the configuration of the item.
        ICollection<GcConfig> Config { get; set; }
        //Specifies the notes.
        string Notes { get; set; }
        //Specifies the type of the item.
        string Type { get; set; }
        //Specifies if the item is over due or not.
        bool IsOverDue { get; set; }
        //Specifies the identification number of the person who archived it.
        int? ArchivedBy { get; set; }
        //Specifies the date and time the item was archived at.
        GcDate ArchivedAt { get; set; }
        //Specifies the date and time the item was created at.
        GcDate CreatedAt { get; set; }
        //Specifies the date and time the item was updated at.
        GcDate UpdatedAt { get; set; }
        //Specifies the current status.
        GcDataObject<GcStatus> CurrentStatus { get; set; }
        //Specifies the due dates of all the items.
        GcDataCollection<GcDueDate> DueDates { get; set; }

    }
}
