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
                    File file = new File("C:/dlloutputs/" + type.Name + ".cs");
                    file.SetFile();

                    File.WritetoLine("using System;");
                    File.WritetoLine("");
                    File.WritetoLine("namespace " + type.Namespace);
                    File.WritetoLine("{");

                    File.WritetoLine("  public enum " + type.Name);
                    File.WritetoLine("  {");

                    string[] enumvalues = type.GetEnumNames();

                    foreach (var value in enumvalues)
                    {
                        File.WritetoLine("  "+value+",");
                    }

                    File.WritetoLine("  }");
                    File.WritetoLine("}");
                    file.CloseConnection();
                }
            }
        }
    }
}
