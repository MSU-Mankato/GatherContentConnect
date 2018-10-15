using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GatherContentConnect.Interface;

namespace GatherContentConnect.Objects
{
    class GcTextType : IGcTextType
    {
        public bool IsRequired { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
        public string MicroCopy { get; set; }
        public string LimitType { get; set; }
        public string Limit { get; set; }
        public bool IsPlainText { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }
}
