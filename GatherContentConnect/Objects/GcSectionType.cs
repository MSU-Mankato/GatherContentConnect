using GatherContentConnect.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatherContentConnect.Objects
{
    class GcSectionType : IGcSectionType
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }
}
