<?php

namespace ReflectionOrnekClass;
include_once 'modelclass.php';

  class Simple extends Model
  {
  public $Position;
  public $Exists;
  public $LastValue;

  public function _types() {
      return [
      'Position' => 'integer',
      'Exists' => 'boolean',
      'LastValue' => 'double',
      ];
  }
  }
?>
