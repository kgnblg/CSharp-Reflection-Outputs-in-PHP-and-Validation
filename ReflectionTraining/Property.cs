using CSharpReflection;
using System.Collections.Generic;

namespace ReflectionTraining
{
    class Property
    {
        List<PropertyElements> propertyinfo { get; set; }

        public Property(List<PropertyElements> propertyinfo)
        {
            this.propertyinfo = propertyinfo;
        }

        public void PrintPropertys()
        {
            foreach (var property in propertyinfo)
            {
                File.WritetoLine("  public $" + property.propertyName.ToLower() + ";");
            }
        }
    }
}
