using System;

namespace ReflectionTraining
{
    class Enum: ITypes
    {
        public Type [] types { get; set; }

        public Enum(Type [] types)
        {
            this.types = types;
        }

        public void PrintIt()
        {
            foreach (var type in types)
            {
                if (type.IsEnum)
                {
                    File file = new File(type.Name);
                    file.SetFile();
                    file.PrintHeader();

                    File.WritetoLine("namespace " + type.Namespace + ";");
                    File.WritetoLine("");

                    File.WritetoLine("  class " + type.Name);
                    File.WritetoLine("  {");

                    var enumvalues = type.GetEnumValues();
                    type.GetEnumUnderlyingType();
                    foreach (var value in enumvalues)
                    {
                        File.WritetoLine("  const " + value.ToString() + " = " + (int)value + ";");
                    }

                    File.WritetoLine("");
                    File.WritetoLine("      public static function _enums() {");
                    File.WritetoLine("          return array ([");

                    foreach (var value in enumvalues)
                    {
                        File.WritetoLine("          '" + (int)value + "' => '" + value.ToString() + "',");
                    }

                    File.WritetoLine("          ]);");
                    File.WritetoLine("      }");

                    File.WritetoLine("  }");
                    file.CloseConnection();
                }
            }
        }
    }
}
