<?php

namespace ReflectionOrnekClass;
use Exception;

class Model {
       public function __construct(array $variables = null){
        if($variables == null){ return; }

        foreach ($variables as $variable => $value){
            if (!property_exists($this, $variable)){
              throw new Exception("Unexpected property: $variable");
           }

            $this->$variable = $value;
        }
    }
       private function getType($value){
        $type = gettype($value);

        if($type == 'object'){ return get_class($value); }

        return $type;
        }
       public function validateVariables(){
            $typeFunctionDatas = $this->_types();

            $getVariableTypes = get_object_vars($this);

            foreach ($typeFunctionDatas[0] as $functionVariable => $functionType){

            $parseFunction = explode('&',$functionType);

            $getFunctionType = $this->getType($getVariableTypes[$functionVariable]);

            if ($getFunctionType != $parseFunction[0]){
              throw new Exception("Unexpected type for: $functionVariable");
       }

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
       public function validateArrays($functionVariable, $parseFunction){
        foreach ($functionVariable as $functionVar){
            $getFunctionVarType = $this->getType($functionVar);

            if ($getFunctionVarType != $parseFunction){
              throw new Exception("Unexpected type for: $functionVariable [], expected: $getFunctionVarType");
       }
        }
    }
       public function validateEnum($variableData, $path){
        $enumVariableList = $path::_enums();

        if (@$enumVariableList[0][$variableData] == null){
                throw new Exception("Unexpected enum for: $variableData, in: $path");       }
    }
}
?>

