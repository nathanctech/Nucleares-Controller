using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeWeb
{
    public class NuclearesVariable(string name, Type t)
    {
        public string Name { get; private set; } = name;
        public string ValueString { get; private set; } = "";
        public Type ValueType { get; init; } = t;

        public object GetValue()
        {
            if (ValueType == typeof(string))
            {
                return ValueString;
            }
            else if (ValueType == typeof(int))
            {
                return int.Parse(ValueString);
            }
            else if (ValueType == typeof(float))
            {
                return float.Parse(ValueString);
            }
            else if (ValueType == typeof(bool))
            {
                return ValueString == "TRUE";
            }
            else
            {
                throw new InvalidOperationException("Unsupported type");
            }
        }

        public void SetValue(object value)
        {
            if (ValueType == typeof(string))
            {
                ValueString = value.ToString()!;
            }
            else if (ValueType == typeof(int))
            {
                ValueString = ((int)value).ToString();
            }
            else if (ValueType == typeof(float))
            {
                ValueString = ((float)value).ToString();
            }
            else if (ValueType == typeof(bool))
            {
                ValueString = (bool)value ? "TRUE" : "FALSE";
            }
            else
            {
                throw new InvalidOperationException("Unsupported type");
            }
        }

        public async void UpdateValue()
        {
            var response = await Request.Get(Name);
            if (response != null)
            {
                ValueString = response;
            }
            else
            {
                throw new Exception($"Failed to update variable: {Name}");
            }
        }
    }
}
