<?php

namespace ReflectionOrnekClass;
include_once 'modelclass.php';

class Ogrenci extends Model
{
  public $ad;
  public $soyad;
  public $asdasdasd;

  public function _types() {
      return [
      'ad' => 'string',
      'soyad' => 'string',
      'asdasdasd' => 'integer',
      ];
}

  public function getAd() {
  return $this->ad;
  }

  public function setAd($value) {
  $this->ad = $value;
  }

  public function getSoyad() {
  return $this->soyad;
  }

  public function setSoyad($value) {
  $this->soyad = $value;
  }

}
?>
