namespace GatherContentConnect.Interface
{
    public interface IGcAnnouncements
    {
        //Specifies the announcement id.
        string Id { get; set; }
        //Specifies the name of the announcement.
        string Name { get; set; }
        //Specifies if the announcement is acknowledged or not.
        bool IsAcknowledged { get; set; }
    }
}