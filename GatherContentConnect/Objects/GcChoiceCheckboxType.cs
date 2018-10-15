using GatherContentConnect.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatherContentConnect.Objects
{
    class GcChoiceCheckboxType : IGcChoiceCheckboxType
    {
        public bool IsRequired { get; set; }
        public string Label { get; set; }
        public string MicroCopy { get; set; }
        public ICollection<GcOption> Options { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }
}
