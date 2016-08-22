using CSharpReflection;
using System.Collections.Generic;

namespace ReflectionTraining
{
    class Enum
    {
        public List<EnumElements> enumelements { get; set; }

        public Enum(List<EnumElements> enumelements)
        {
            this.enumelements = enumelements;
        }

        public void PrintEnumBody()
        {
            foreach (var enumelement in enumelements)
            {
                PrintEnumHeader(enumelement);

                foreach (var value in enumelement.enumFields)
                {
                    File.WritetoLine("  const " + value.enumValue + " = " + value.enumNumberValue + ";");
                }

                PrintEnumsFunction(enumelement.enumFields);

                PrintEnumFooter();
            }
        }

        public void PrintEnumHeader(EnumElements enumelement)
        {
            File file = new File(enumelement.enumName);
            file.SetFile();
            file.PrintHeader();

            File.WritetoLine("namespace " + enumelement.enumNamespace + ";");
            File.WritetoLine("");

            File.WritetoLine("  class " + enumelement);
            File.WritetoLine("  {");
        }

        public void PrintEnumFooter()
        {
            File.WritetoLine("  }");
            File.CloseConnection();
        }

        public void PrintEnumsFunction(List<EnumFields> enumfields)
        {
            File.WritetoLine("");
            File.WritetoLine("      public static function _enums() {");
            File.WritetoLine("          return array ([");

            foreach (var value in enumfields)
            {
                File.WritetoLine("          '" + value.enumNumberValue + "' => '" + value.enumValue + "',");
            }

            File.WritetoLine("          ]);");
            File.WritetoLine("      }");
        }
    }
}
