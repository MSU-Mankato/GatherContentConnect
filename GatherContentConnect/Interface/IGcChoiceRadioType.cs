using GatherContentConnect.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatherContentConnect.Interface
{
    interface IGcChoiceRadioType:IGcElement
    {
        //Specifies if the elementis required or not.
        bool IsRequired { get; set; }
        //Specifies the Label.
        string Label { get; set; }
        //Specifies the micro copy of the element.
        string MicroCopy { get; set; }
       //Specifies if there are any other options.
        bool IsOtherOption { get; set; }
        //Specifies the collection of options.
        ICollection<GcOption> Options { get; set; }
    }
}
