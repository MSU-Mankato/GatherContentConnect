using GatherContentConnect.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatherContentConnect.Objects
{
    public class GcElementsTypeConverter : Newtonsoft.Json.Converters.CustomCreationConverter<IGcElement>
    {
        public override IGcElement Create(Type objectType)
        {
            throw new NotImplementedException();
        }

        public IGcElement Create(Type objectType, JObject jObject)
        {
            var type = (string)jObject.Property("type");

            switch (type)
            {
                case "files":
                    return new GcFileElement();
                case "text":
                    return new GcTextElement();
                case "section":
                    return new GcSectionElement();
                case "choice_checkbox":
                    return new GcChoiceCheckboxElement();
                case "choice_radio":
                    return new GcChoiceRadioElement();
            }

            throw new ApplicationException(String.Format("The GC ELement type {0} is not supported!", type));

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream 
            JObject jObject = JObject.Load(reader);

            // Create target object based on JObject 
            var target = Create(objectType, jObject);

            // Populate the object properties 
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        } 
    }
}