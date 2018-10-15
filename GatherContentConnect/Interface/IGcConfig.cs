using System.Collections.Generic;
using GatherContentConnect.Objects;

namespace GatherContentConnect.Interface
{
    public interface IGcConfig
    {
        //Specifies the label of the configuration.
        string Label { get; set; }
        //Specifies the name.
        string Name { get; set; }
        //Specifies if the configuration is hidden or not.
        bool IsHidden { get; set; }
        //Specifies the set of elements.
        ICollection<GcElement> Elements { get; set; }

    }
}
