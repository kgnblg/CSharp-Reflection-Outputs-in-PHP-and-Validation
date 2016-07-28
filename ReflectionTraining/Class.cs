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

            File.WritetoLine("namespace " + types[1].Namespace +";");
            File.WritetoLine("use Exception;");
            File.WritetoLine("");
            File.WritetoLine("class Model {");
            File.WritetoLine("");

            //Write Construct
            File.Write(@"   public function __construct(array $variables = null){
        if($variables == null){ return; }

        foreach ($variables as $variable => $value){
            if (!property_exists($this, $variable)){
");
            File.WritetoLine("throw new Exception(\"Unexpected property: $variable\");");
            File.Write(@"}

            $this->$variable = $value;
        }
}
");

            //Write getType()
            File.Write(@"   private function getType($value){
        $type = gettype($value);

        if($type == 'object'){ return get_class($value); }

        return $type;
        }
");

            //Write ValidateVariables()
            File.Write(@"   public function validateVariables(){
        $typeFunctionDatas = $this->_types();

        $getVariableTypes = get_object_vars($this);

        foreach ($typeFunctionDatas[0] as $functionVariable => $functionType){

            $parseFunction = explode('&',$functionType);

            $getFunctionType = $this->getType($getVariableTypes[$functionVariable]);

            if ($getFunctionType != $parseFunction[0]){
");
            File.WritetoLine("throw new Exception(\"Unexpected type for: $functionVariable\");");
            File.Write(@"}

            if (count($parseFunction) >= 2){
                if ($parseFunction[0] == 'array'){
                    $this->validateArrays($getVariableTypes[$functionVariable], $parseFunction[1]);
    }

                if ($parseFunction[1] == 'enum'){
                    $this->validateEnum($getVariableTypes[$functionVariable], $parseFunction[2]);
    }
}
        }
    }
");

            //Write ValidateArrays()
            File.Write(@"   public function validateArrays($functionVariable, $parseFunction){
        foreach ($functionVariable as $functionVar){
            $getFunctionVarType = $this->getType($functionVar);

            if ($getFunctionVarType != $parseFunction){
");
            File.WritetoLine("throw new Exception(\"Unexpected type for: $functionVariable[], expected: $getFunctionVarType\");");
            File.Write(@"}
    }
}
");
            File.Write(@"public function validateEnum($variableData, $path){
        $enumVariableList = $path::_enums();

        if (@$enumVariableList[$variableData] == null){
");
            File.Write("throw new Exception(\"Unexpected enum for: $variableData, in: $path\");");
        File.Write(@"}
}
");

            File.WritetoLine("}");
            File.WritetoLine("?>");
            file.CloseConnection();
        }
    }
}
