using System.Collections.Generic;
using GatherContentConnect.Objects;

namespace GatherContentConnect.Interface
{
    public interface IGcTemplate
    {
        //Specifies the identification number of the Template.
        int Id { get; set; }
        //Specifies the identification number of the project.
        int ProjectId { get; set; }
        //Specifies the  identification number of the creator.
        int CreatedBy { get; set; }
        //Specifies the identification number of the updater .
        int UpdatedBy { get; set; }
        //Specifies the name of the template.
        string Name { get; set; }
        //Specifies the description of the template.
        string Description { get; set; }
        //Specifies the configuration of the template.
        ICollection<GcConfig> Config { get; set; }
        //Specifies the date and time when the template was used.
        string UsedAt { get; set; }
        //Specifies the date and time the template was created at.
        int CreatedAt { get; set; }
        //Specifies the date and time the template was updated at.
        int UpdatedAt { get; set; }
        //Specifies the item count.
        GcUsage Usage { get; set; }
    
    }
}