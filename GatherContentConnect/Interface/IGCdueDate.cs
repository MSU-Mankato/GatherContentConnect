using GatherContentConnect.Objects;

namespace GatherContentConnect.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGcDueDate
    {
        //The unique ID used to identify a DueDate
        int StatusId { get; set; }

        //Specifies if the Date has passed
        bool IsOverDue { get; set; }

        //The Date and Time when someone/something is due.
        GcDate Date { get; set; }
    }
}
