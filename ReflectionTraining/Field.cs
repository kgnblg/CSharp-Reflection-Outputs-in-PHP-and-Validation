using CSharpReflection;
using System.Collections.Generic;

namespace ReflectionTraining
{
    class Field
    {
        List<FieldElements> fieldelements { get; set; }
        public Field(List<FieldElements> fieldelements)
        {
            this.fieldelements = fieldelements;
        }
        
        public void PrintFields()
        {
            foreach (var field in fieldelements)
            {
                File.WritetoLine("  public $" + field.fieldName + ";");
            }
        }
    }
}
