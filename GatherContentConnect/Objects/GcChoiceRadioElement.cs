using GatherContentConnect.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatherContentConnect.Objects
{
    class GcChoiceRadioElement: IGcElement
    {
        public string Type { get; set; }
        //Specifies the name of the element.
        public string Name { get; set; }
        //Specifies if the elementis required or not.
        bool IsRequired { get; set; }
        //Specifies the Label.
        string Label { get; set; }
        //Specifies the micro copy of the element.
        string MicroCopy { get; set; }
        //Specifies if there are any other options.
        bool IsOtherOption { get; set; }
        //Specifies the collection of options.
        ICollection<IGcOption> Options { get; set; }
    }
}
