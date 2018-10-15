using System.Collections.Generic;

namespace GatherContentConnect.Interface
{
    public interface IGcDataCollection<T>
    {
        ICollection<T> Data { get; set; }
    }
}
