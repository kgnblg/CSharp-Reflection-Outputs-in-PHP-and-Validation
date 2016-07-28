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
                    File file = new File("C:/dlloutputs/" + type.Name + ".php");
                    file.SetFile();

                    File.WritetoLine("<?php");
                    File.WritetoLine("");
                    File.WritetoLine("namespace " + type.Namespace + ";");
                    File.WritetoLine("include_once 'modelclass.php';");
                    File.WritetoLine("");

                    File.WritetoLine("  class " + type.Name + " extends Model");
                    File.WritetoLine("  {");

                    Field field = new Field(type.GetFields());
                    field.PrintFields();
                    File.WritetoLine("");
                    field.CreateTypesMethod();

                    File.WritetoLine("  }");
                    File.WritetoLine("?>");
                    file.CloseConnection();
                }
            }
        }
    }
}
