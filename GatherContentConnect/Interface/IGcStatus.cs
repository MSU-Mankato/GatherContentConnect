namespace GatherContentConnect.Interface
{
    public interface IGcStatus
    {
        //Specifies the identification number of the status.
        string Id { get; set; }
        //Specifies if the status is default or not.
        bool IsDefault { get; set; }
        //Specifies the position.
        string Position { get; set; }
        //Specifies the color.
        string Color { get; set; }
        //Specifies the name of the status.
        string Name { get; set; }
        //Describes the status in detail.
        string Description { get; set; }
        //Specifies if editable or not.
        bool CanEdit { get; set; }
    }
}
