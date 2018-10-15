using System.Collections.Generic;
using GatherContentConnect.Objects;

namespace GatherContentConnect.Interface
{
    public interface IGcElement
    {
        //Specifies the type of the element.
        string Type { get; set; }
        //Specifies the name of the element.
        string Name { get; set; }
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
        
         int? Limit { get; set; }
        //Specifies if it is a plain text or not.
         bool IsPlainText { get; set; }
        //Specifies the title. This is only applicable in Items.
        
         string Title { get; set; }
        //Specifies the subtitle. This is only applicable in Items.
        
         string Subtitle { get; set; }
        //Specifies if there are any other options.
         bool IsOtherOption { get; set; }
        //Specifies the collection of options.
        
         ICollection<GcOption> Options { get; set; }
    }
}
