using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatherContentConnect.Interface
{
    interface IGcSectionType:IGcElement
    {
        //Specifies the title. This is only applicable in Items.
        string Title { get; set; }
        //Specifies the subtitle. This is only applicable in Items.
        string Subtitle { get; set; }
    }
}
