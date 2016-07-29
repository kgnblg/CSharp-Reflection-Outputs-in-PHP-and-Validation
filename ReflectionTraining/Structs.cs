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
                    File file = new File(type.Name);
                    file.SetFile();
                    file.PrintHeader();
                    
                    File.WritetoLine("namespace " + type.Namespace + ";");
                    File.WritetoLine("include_once 'modelclass.php';");
                    File.WritetoLine("");

                    File.WritetoLine("  class " + type.Name + " extends Model");
                    File.WritetoLine("  {");

                    Field field = new Field(type.GetFields());
                    field.PrintFields();
                    File.WritetoLine("");

                    TypeWriter typewrite = new TypeWriter(type.GetFields());
                    typewrite.CreateTypesFunction();

                    File.WritetoLine("  }");
                    file.CloseConnection();
                }
            }
        }
    }
}
