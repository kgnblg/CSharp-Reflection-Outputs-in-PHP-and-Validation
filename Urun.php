<?php

namespace ReflectionOrnekClass;
include_once 'modelclass.php';

class Urun extends Model
{
  public $urunkod;
  public $urunad;
  public $stok;

  public function _types() {
      return [
      'urunkod' => 'string',
      'urunad' => 'string',
      'stok' => 'integer',
      ];
}

  public function getUrunkod() {
  return $this->urunkod;
  }

  public function setUrunkod($value) {
  $this->urunkod = $value;
  }

  public function getUrunad() {
  return $this->urunad;
  }

  public function setUrunad($value) {
  $this->urunad = $value;
  }

  public function getStok() {
  return $this->stok;
  }

  public function setStok($value) {
  $this->stok = $value;
  }

}
?>
