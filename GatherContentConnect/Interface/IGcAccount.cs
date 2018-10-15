namespace GatherContentConnect.Interface
{
    public interface IGcAccount
    {
        //Specifies the identification number of the account.
        string Id { get; set; }
        //Specifies the name of the account.
        string Name { get; set; }
        //Specifies the slug property.
        string Slug { get; set; }
        //Specifies the time zone.
        string TimeZone { get; set; }

    }
}
