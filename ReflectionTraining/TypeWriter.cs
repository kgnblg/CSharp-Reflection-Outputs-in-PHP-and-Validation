using System;
using System.Reflection;

namespace ReflectionTraining
{
    class TypeWriter
    {
        public FieldInfo[] fieldinfo { get; set; }
        public PropertyInfo [] propertyinfo { get; set; }

        public TypeWriter(FieldInfo[] fieldinfo)
        {
            this.fieldinfo = fieldinfo;
        }

        public TypeWriter(FieldInfo [] fieldinfo, PropertyInfo [] propertyinfo)
        {
            this.fieldinfo = fieldinfo;
            this.propertyinfo = propertyinfo;
        }

        public void CreateTypesFunction()
        {
            File.WritetoLine("  public function _types() {");
            File.WritetoLine("      return [");

            foreach (var field in fieldinfo)
            {
                string typeresult = TypeFinder.FindTypeforField(field);

                File.WritetoLine("      '" + field.Name + "' => '" + typeresult + "',");
            }

            if (propertyinfo != null)
            {
                foreach (var property in propertyinfo)
                {
                    string propertytype = TypeFinder.FindTypeforProperty(property);

                    File.WritetoLine("      '" + property.Name.ToLower() + "' => '" + propertytype + "',");
                }
            }
            
            File.WritetoLine("      ];");
            File.WritetoLine("  }");
        }

        public static void CreateEnumsFunction(Array enumvalues)
        {
            File.WritetoLine("");
            File.WritetoLine("      public static function _enums() {");
            File.WritetoLine("          return array ([");

            foreach (var value in enumvalues)
            {
                File.WritetoLine("          '" + (int)value + "' => '" + value.ToString() + "',");
            }

            File.WritetoLine("          ]);");
            File.WritetoLine("      }");
        }
    }
}
