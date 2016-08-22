using CSharpReflection;
using System.Collections.Generic;

namespace ReflectionTraining
{
    class Structs
    {
        public List<StructElements> structelements { get; set; }

        public Structs(List<StructElements> structelements)
        {
            this.structelements = structelements;
        }

        public void PrintStructBody()
        {
            foreach (var structelement in structelements)
            {
                PrintStructHeader(structelement);

                Field field = new Field(structelement.structFields);
                field.PrintFields();

                TypeWriter typewriter = new TypeWriter(structelement.structFields);
                typewriter.PrintTypesFunction();

                PrintStructFooter();
            }
        }

        public void PrintStructHeader(StructElements structvariable)
        {
            File file = new File(structvariable.structName);
            file.SetFile();
            file.PrintHeader();

            File.WritetoLine("namespace " + structvariable.structNamespace + ";");
            File.WritetoLine("include_once 'Validate.php';");
            File.WritetoLine("");

            File.WritetoLine("  class " + structvariable.structName + " extends Validate");
            File.WritetoLine("  {");
        }

        public void PrintStructFooter()
        {
            File.WritetoLine("  }");
            File.CloseConnection();
        }


    }
}
