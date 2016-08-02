using System;
using System.Reflection;

namespace ReflectionTraining
{
    class Field
    {
        public FieldInfo [] fieldinfo { get; set; }
        public Field(FieldInfo [] fieldinfo)
        {
            this.fieldinfo = fieldinfo;
        }
        
        public void PrintFields()
        {
            foreach (var field in fieldinfo)
            {
                File.WritetoLine("  public $"+field.Name+";");
            }
        }
    }
}
