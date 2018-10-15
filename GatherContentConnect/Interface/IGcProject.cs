using GatherContentConnect.Objects;

namespace GatherContentConnect.Interface
{
    public interface IGcProject
    {
        //Specifies the identification number of the project.
        int Id { get; set; }
        //Specifies the name of the project.
        string Name { get; set; }
        //Specifies the type of the project.
        string Type { get; set; }
        //Specifies if the example is true or not.
        bool Example { get; set; }
        //Specifies the account identification number.
        int AccountId { get; set; }
        //Specifies the text direction.
        string TextDirection { get; set; }
        //Specifies the tags allowed.
        string AllowedTags { get; set; }
        //Specifies the created at property.
        int CreatedAt { get; set; }
        //Specifies the updated at property.
        int UpdatedAt { get; set; }
        //Specifies if the project is over due.
        bool IsOverDue { get; set; }
        //Lists the statuses present in each project.
        GcDataCollection<GcStatus> Statuses { get; set; }


    }
}
