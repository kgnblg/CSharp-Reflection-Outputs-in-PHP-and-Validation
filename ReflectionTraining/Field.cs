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

        public void CreateTypesMethod()
        {
            File.WritetoLine("  public function _types() {");
            File.WritetoLine("      return [");

            foreach (var field in fieldinfo)
            {
                string typeresult = TypeFinder.FindType(field);

                File.WritetoLine("      '" + field.Name + "' => '" + typeresult + "',");
            }

            File.WritetoLine("      ];");
            File.WritetoLine("  }");
        }
    }
}
