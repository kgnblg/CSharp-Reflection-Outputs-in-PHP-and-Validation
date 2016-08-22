using CSharpReflection;
using System.Collections.Generic;

namespace ReflectionTraining
{
    class FieldSeperator
    {
        List<FieldElements> fieldelements;
        public List<FieldElements> genericFields = new List<FieldElements>();
        public List<FieldElements> normalFields = new List<FieldElements>();

        public FieldSeperator(List<FieldElements> fieldelements)
        {
            this.fieldelements = fieldelements;
        }

        public void SeperateFields()
        {
            foreach (var fieldelement in fieldelements)
            {
                if (fieldelement.FieldType.IsGenericType)
                {
                    genericFields.Add(fieldelement);
                }
                else
                {
                    normalFields.Add(fieldelement);
                }
            }
        }
    }
}
