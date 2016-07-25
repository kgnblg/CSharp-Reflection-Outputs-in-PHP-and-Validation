using System;
using System.Reflection;

namespace ReflectionTraining
{
    class Class: ITypes
    {
        public Type[] types { get; set; }

        public Class(Type [] types)
        {
            this.types = types;
        }

        public void PrintIt()
        {
            foreach (var type in types)
            {
                if (type.IsClass)
                {
                    File file = new File("C:/dlloutputs/" + type.Name + ".php");
                    file.SetFile();

                    File.WritetoLine("<?php");
                    File.WritetoLine("");
                    File.WritetoLine("namespace " + type.Namespace+";");
                    File.WritetoLine("include_once 'modelclass.php';");
                    File.WritetoLine("");

                    File.WritetoLine("class " + type.Name + " extends Model");
                    File.WritetoLine("{");

                    Field field = new Field(type.GetFields());
                    field.PrintFields();
                    File.WritetoLine("");
                    field.CreateTypesMethod();

                    File.WritetoLine("");

                    PropertyInfo[] propertyinfos = type.GetProperties();
                    Property property = new Property(propertyinfos);
                    property.PrintPropertys();

                    File.WritetoLine("}");
                    File.WritetoLine("?>");
                    file.CloseConnection();
                }
            }
        }

        public void CreateModelClass()
        {
            File file = new File("C:/dlloutputs/modelclass.php");
            file.SetFile();

            File.WritetoLine("<?php");
            File.WritetoLine("");

            File.WritetoLine("namespace " + types[1].Namespace);
            File.WritetoLine("use Exception;");
            File.WritetoLine("");
            File.WritetoLine("class Model {");
            File.WritetoLine("");

            //Write Construct
            File.Write(@"   public function __construct(array $props = null){
        if ($props == null)
            return;
        foreach ($props as $prop => $value){
                if (!property_exists($this, $prop))
");
            File.WritetoLine("              throw new Exception(\"Unexpected property: $prop\");");
            File.Write(@"   $this->$prop = $value;
    }
}
");

            //Write Validate()
            File.Write(@"   public function validate(){
        $types = $this->_types();
        $props = get_object_vars($this);
        foreach($props as $prop => $value){
            $expectedType = explode('`',$types[$prop]);
            $type = $this->getType($value);
            if($expectedType[0] != $type)
");
            File.WritetoLine("              throw new Exception(\"Unexpected type for: $prop\");");
                    File.Write(@"       if (count($expectedType) == 2 && $expectedType[0] == 'array'){
            $this->validateArray($value, $prop, $expectedType[1]);
            }
        }
    }
");

            //Write ValidateArray()
            File.Write(@"   private function validateArray($values, $prop, $expectedType){
        foreach ($values as $value){
            $type = $this->getType($value);
            if ($expectedType != $type)
");
            File.WritetoLine("              throw new Exception(\"Unexpected type for: $prop [], expected: $expectedType, was: $type\");");
            File.Write(@"       }
    }
");

            //Write GetType()
            File.Write(@"   private function getType($value){
        $type = gettype($value);
        if ($type == 'object')
            return get_class($value);
        return $type;
    }
");

            File.WritetoLine("}");
            File.WritetoLine("?>");
            file.CloseConnection();
        }
    }
}
