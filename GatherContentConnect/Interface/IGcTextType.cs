using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatherContentConnect.Interface
{
    public interface IGcTextType:IGcElement
    {
        //Specifies if the elementis required or not.
        bool IsRequired { get; set; }
        //Specifies the Label.
        string Label { get; set; }
        //Specifies the value registered to the element.
        string Value { get; set; }
        //Specifies the micro copy of the element.
        string MicroCopy { get; set; }
        //Specifies the type of the limit.
        string LimitType { get; set; }
        //Specifies the limit.
        string Limit { get; set; }
        //Specifies if it is a plain text or not.
        bool IsPlainText { get; set; }
        //Specifies if there are any other options.
     
    }
}
