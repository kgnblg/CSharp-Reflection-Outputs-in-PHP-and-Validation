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
                    File file = new File("C:/dlloutputs/" + type.Name + ".php");
                    file.SetFile();

                    File.WritetoLine("<?php");
                    File.WritetoLine("");
                    File.WritetoLine("namespace " + type.Namespace + ";");
                    File.WritetoLine("");

                    File.WritetoLine("  class " + type.Name);
                    File.WritetoLine("  {");

                    string[] enumvalues = type.GetEnumNames();

                    foreach (var value in enumvalues)
                    {
                        File.WritetoLine("  const "+value+";");
                    }

                    File.WritetoLine("  }");
                    File.WritetoLine("}");
                    File.WritetoLine("?>");
                    file.CloseConnection();
                }
            }
        }
    }
}
