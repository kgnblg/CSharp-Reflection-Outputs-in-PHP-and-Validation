<?php

namespace ReflectionOrnekClass;
include_once 'Validate.php';

  class Simple extends Validate
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

