<?php

namespace Account;
use Exception;

class Model {
    public function __construct(array $props = null){
        if($props == null)
            return;
        foreach($props as $prop => $value){
            if(!property_exists($this, $prop))
                throw new Exception("Unexpected property: $prop");
            $this->$prop = $value;
        }
    }

    public function validate(){
        $types = $this->_types();
        $props = get_object_vars($this);
        foreach($props as $prop => $value){
            $expectedType = explode('`',$types[$prop]);
            $type = $this->getType($value);
            if($expectedType[0] != $type)
                throw new Exception("Unexpected type for: $prop");
            if(count($expectedType) == 2 && $expectedType[0] == 'array'){
                $this->validateArray($value, $prop, $expectedType[1]);
            }

        }
    }

    private function validateArray($values, $prop, $expectedType){
        foreach($values as $value){
            $type = $this->getType($value);
            if($expectedType != $type)
                throw new Exception("Unexpected type for: $prop [], expected: $expectedType, was: $type");
        }
    }

    private function getType($value){
        $type = gettype($value);
        if($type == 'object')
            return get_class($value);
        return $type;
    }
}

/*class User extends Model {
    public $name;
    public $surname;
    public $age;
    public $address;
    public $roles;

    public function _types(){
        return [
            'name' => 'string',
            'surname' => 'string',
            'age' => 'integer',
            'address' => 'Paximum\Account\Address',
            'roles' => 'array`Paximum\Account\Role'
        ];
    }
}*/


/*class Address {
    public $street;
}

class Role {
    public $name;
}

$address = new Address;
$address->street = "Guzeloluk";

$u = new User([
    'name' => 'vitaliy',
    'surname' => 'tsvayer',
    'age' => '36',
    'address' => new Address,
    'roles' => [
        new Role,
        new Role
    ]
]);

$u->validate();
echo json_encode($u);

//var_dump($u->validate());*/
?>