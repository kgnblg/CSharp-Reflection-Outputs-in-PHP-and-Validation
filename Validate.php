<?php
/**
 * Created by PhpStorm.
 * User: KGN
 * Date: 25.07.2016
 * Time: 15:30
 */

namespace Account;
use Exception;

class Validate
{
    public function __construct(array $variables = null){
        if($variables == null){ return; }

        foreach ($variables as $variable => $value){
            if (!property_exists($this, $variable)){
                throw new Exception("Unexpected property: $variable");
            }

            $this->$variable = $value;
        }
    }

    public function getType($value){
        $type = gettype($value);

        if($type == "object"){ return get_class($value); }

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
                if ($parseFunction[0] == "array"){
                    if ($parseFunction[1] == "single")
                    {
                        $this->validateSingleArrays($getVariableTypes[$functionVariable], $parseFunction[2]);
                    }else{
                        $this->validateMultipleArrays($getVariableTypes[$functionVariable], $parseFunction[2], $parseFunction[3]);
                    }
                }

                if ($parseFunction[1] == "enum"){
                    $this->validateEnum($getVariableTypes[$functionVariable], $parseFunction[2]);
                }
            }
        }
    }

    public function validateSingleArrays($functionVariable, $parseFunction){
        foreach ($functionVariable as $functionVar){
            $getFunctionVarType = $this->getType($functionVar);

            if ($getFunctionVarType != $parseFunction){
                throw new Exception("Unexpected type for: $functionVariable [], expected: $getFunctionVarType");
            }
        }
    }

    public function validateMultipleArrays($functionVariable, $firstVariableType, $secondVariableType){
        foreach ($functionVariable as $functionName => $functionInside){
            $getFirstType = $this->getType($functionName);
            $getSecondType = $this->getType($functionInside);

            if ($getFirstType != $firstVariableType){
                throw new Exception("Unexpected Type for: $functionVariable [] multiple array, expected $firstVariableType");
            }

            if ($getSecondType != $secondVariableType){
                throw new Exception("Unexpected Type for: $functionVariable [] multiple array, expected $secondVariableType");
            }
        }
    }

    public function validateEnum($variableData, $path){
        $enumVariableList = $path::_enums();

        if (@$enumVariableList[0][$variableData] == null){
            throw new Exception("Unexpected enum for: $variableData, in: $path");
        }
    }
}
?>