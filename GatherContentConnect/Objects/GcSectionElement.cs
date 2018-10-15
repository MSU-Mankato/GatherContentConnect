using GatherContentConnect.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatherContentConnect.Objects
{
    class GcSectionElement: IGcElement
    {
        public string Type { get; set; }
        //Specifies the name of the element.
        public string Name { get; set; }
        //Specifies the title. This is only applicable in Items.
        string Title { get; set; }
        //Specifies the subtitle. This is only applicable in Items.
        string Subtitle { get; set; }
    }
}
