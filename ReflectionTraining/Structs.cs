using System;

namespace ReflectionTraining
{
    class Structs: ITypes
    {
        public Type[] types { get; set; }

        public Structs(Type[] types)
        {
            this.types = types;
        }

        public void PrintIt()
        {
            foreach (var type in types)
            {
                if (type.IsValueType && type.IsEnum == false)
                {
                    File file = new File("C:/dlloutputs/" + type.Name + ".cs");
                    file.SetFile();

                    File.WritetoLine("using System;");
                    File.WritetoLine("");
                    File.WritetoLine("namespace " + type.Namespace);
                    File.WritetoLine("{");

                    File.WritetoLine("  public struct " + type.Name);
                    File.WritetoLine("  {");

                    Field field = new Field(type.GetFields());
                    field.PrintFields();

                    File.WritetoLine("  };");
                    File.WritetoLine("}");
                    file.CloseConnection();
                }
            }
        }
    }
}
