using CSharpReflection;
using System.Collections.Generic;

namespace ReflectionTraining
{
    class Class
    {
        public List<ClassElements> classelements { get; set; }

        public Class(List<ClassElements> classelements)
        {
            this.classelements = classelements;
        }

        public void PrintClassBody()
        {
            foreach (var classelement in classelements)
            {
                PrintClassHeader(classelement);

                Field field = new Field(classelement.classFields);
                field.PrintFields();

                File.WritetoLine("");

                Property property = new Property(classelement.classPropertys);
                property.PrintPropertys();

                TypeWriter typewriter = new TypeWriter(classelement.classFields, classelement.classPropertys);
                typewriter.PrintTypesFunction();

                PrintClassFooter();
            }
        }

        public void PrintClassHeader(ClassElements classelement)
        {
            File file = new File(classelement.className);
            file.SetFile();
            file.PrintHeader();

            File.WritetoLine("namespace " + classelement.classNamespace + ";");
            File.WritetoLine("include_once 'Validate.php';");
            File.WritetoLine("");

            File.WritetoLine("class " + classelement.className + " extends Validate");
            File.WritetoLine("{");
        }

        public void PrintClassFooter()
        {
            File.WritetoLine("}");
            File.CloseConnection();
        }

        public void CreateModelClass()
        {
            File file = new File("Validate");
            file.SetFile();
            file.PrintHeader();

            File.WritetoLine("namespace " + classelements[0].classNamespace +";");
            File.WritetoLine("use Exception;");
            File.WritetoLine("");
            File.WritetoLine("class Validate {");

            //Write Construct
            File.Write(@"       public function __construct(array $variables = null){
        if($variables == null){ return; }

        foreach ($variables as $variable => $value){
            if (!property_exists($this, $variable)){
");
            File.WritetoLine("              throw new Exception(\"Unexpected property: $variable\");");
            File.Write(@"           }

            $this->$variable = $value;
        }
    }
");

            //Write getType()
            File.Write(@"       private function getType($value){
        $type = gettype($value);

        if($type == 'object'){ return get_class($value); }

        return $type;
        }
");

            //Write ValidateVariables()
            File.Write(@"       public function validateVariables(){
            $typeFunctionDatas = $this->_types();

            $getVariableTypes = get_object_vars($this);

            foreach ($typeFunctionDatas[0] as $functionVariable => $functionType){

            $parseFunction = explode('&',$functionType);

            $getFunctionType = $this->getType($getVariableTypes[$functionVariable]);

            if ($getFunctionType != $parseFunction[0]){
");
            File.WritetoLine("              throw new Exception(\"Unexpected type for: $functionVariable\");");
            File.Write(@"       }

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
            File.Write(@"       public function validateArrays($functionVariable, $parseFunction){
        foreach ($functionVariable as $functionVar){
            $getFunctionVarType = $this->getType($functionVar);

            if ($getFunctionVarType != $parseFunction){
");
            File.WritetoLine("              throw new Exception(\"Unexpected type for: $functionVariable [], expected: $getFunctionVarType\");");
            File.Write(@"       }
        }
    }
");
            //Write validateEnum()
            File.Write(@"       public function validateEnum($variableData, $path){
        $enumVariableList = $path::_enums();

        if (@$enumVariableList[0][$variableData] == null){
");
            File.Write("                throw new Exception(\"Unexpected enum for: $variableData, in: $path\");");
        File.Write(@"       }
    }
");

            File.WritetoLine("}");
            File.CloseConnection();
        }
    }
}
