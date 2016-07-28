<?php

namespace ReflectionOrnekClass;
include_once 'modelclass.php';

class Ogrenci extends Model
{
  public $ad;
  public $soyad;
  public $kgnblg;
  public $asdasdasd;
  public $haha;
  public $kagan;

  public function _types() {
      return array [
      'ad' => 'string',
      'soyad' => 'string',
      'kgnblg' => 'array&integer',
      'asdasdasd' => 'integer',
      'haha' => 'ReflectionOrnekClass\Urun',
      'kagan' => 'integer&enum&ReflectionOrnekClass\Candidates',
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
