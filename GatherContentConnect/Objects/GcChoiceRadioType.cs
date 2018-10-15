using GatherContentConnect.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatherContentConnect.Objects
{
    class GcChoiceRadioType : IGcChoiceRadioType
    {
        bool IGcChoiceRadioType.IsRequired { get; set; }
        string IGcChoiceRadioType.Label { get; set; }
        string IGcChoiceRadioType.MicroCopy { get; set; }
        bool IGcChoiceRadioType.IsOtherOption { get; set; }
        ICollection<GcOption> IGcChoiceRadioType.Options { get; set; }
        string IGcElement.Type { get; set; }
        string IGcElement.Name { get; set; }
    }
}
