using CSharpReflection;
using System.Collections.Generic;

namespace ReflectionTraining
{
    class PropertySeperator
    {
        List<PropertyElements> propertyelements;
        public List<PropertyElements> genericPropertys = new List<PropertyElements>();
        public List<PropertyElements> normalPropertys = new List<PropertyElements>();

        public PropertySeperator(List<PropertyElements> propertyelements)
        {
            this.propertyelements = propertyelements;
        }

        public void SeperatePropertys()
        {
            foreach (var propertyelement in propertyelements)
            {
                if (propertyelement.propertyType.IsGenericType)
                {
                    genericPropertys.Add(propertyelement);
                }
                else
                {
                    normalPropertys.Add(propertyelement);
                }
            }
        }
    }
}
