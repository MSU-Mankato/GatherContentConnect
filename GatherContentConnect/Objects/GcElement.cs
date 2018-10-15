using System.Collections.Generic;
using GatherContentConnect.Interface;
using Newtonsoft.Json;

namespace GatherContentConnect.Objects
{
    public class GcElement : IGcElement
    {
        //Specifies the type of the element.
        [JsonProperty("type")]
        public string Type { get; set; }
        //Specifies the name of the element.
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("required")]
        public bool IsRequired { get; set; }
        //Specifies the Label.
        [JsonProperty("label")]
        public string Label { get; set; }
        //Specifies the value registered to the element.
        [JsonProperty("value")]
        public string Value { get; set; }
        //Specifies the micro copy of the element.
        [JsonProperty("microcopy")]
        public string MicroCopy { get; set; }
        //Specifies the type of the limit.
        [JsonProperty("limit_type")]
        public string LimitType { get; set; }
        //Specifies the limit.
        [JsonProperty("limit")]
        public int? Limit { get; set; }
        //Specifies if it is a plain text or not.
        [JsonProperty("plain_text")]
        public bool IsPlainText { get; set; }
        //Specifies the title. This is only applicable in Items.
        [JsonProperty("title")]
        public string Title { get; set; }
        //Specifies the subtitle. This is only applicable in Items.
        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }
        //Specifies if there are any other options.
        [JsonProperty("other_option")]
        public bool IsOtherOption { get; set; }
        //Specifies the collection of options.
        [JsonProperty("options")]
        public ICollection<GcOption> Options { get; set; }

        /* Following methods will determine whether or not a property needs to be serialized. */
        public bool ShouldSerializeIsPlainText() => Type == "text";
        public bool ShouldSerializeIsOtherOption() => Type == "choice_radio";
        public bool ShouldSerializeIsRequired() => Type != "section";
        public bool ShouldSerializeLabel() => Type != "section";
        public bool ShouldSerializeValue() => Type == "text";
        public bool ShouldSerializeMicroCopy() => Type != "section";
        public bool ShouldSerializeLimitType() => Type == "text";
        public bool ShouldSerializeLimit() => Type == "text";
        public bool ShouldSerializeTitle() => Type == "section";
        public bool ShouldSerializeSubtitle() => Type == "section";
        public bool ShouldSerializeOptions() => Type == "choice_radio" || Type == "choice_checkbox";
    }
}
