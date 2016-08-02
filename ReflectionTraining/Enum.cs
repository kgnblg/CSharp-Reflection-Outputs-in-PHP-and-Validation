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

                    foreach (var value in enumvalues)
                    {
                        File.WritetoLine("  const " + value.ToString() + " = " + (int)value + ";");
                    }

                    TypeWriter.CreateEnumsFunction(enumvalues);

                    File.WritetoLine("  }");
                    file.CloseConnection();
                }
            }
        }
    }
}
