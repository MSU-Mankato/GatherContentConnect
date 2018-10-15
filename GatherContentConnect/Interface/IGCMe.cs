using System.Collections.Generic;
using GatherContentConnect.Objects;

namespace GatherContentConnect.Interface
{
    public interface IGcMe
    {
        //Specifies the Email id of the user.
        string Email { get; set; }
        //Specifies the first name of the user.
        string FirstName { get; set; }
        //Specifies the last name of the user.
        string LastName { get; set; }
        //Specifies the time zone.
        string TimeZone { get; set; }
        //Specifies the Language.
        string Language { get; set; }
        //Specifies the Gender.
        string Gender { get; set; }
        //Specifies the Image Url.
        string Avatar { get; set; }
        //Specifies the announcements collection.
        ICollection<GcAnnouncements> Announcements { get; set; }
    }
}