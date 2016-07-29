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

  public $ad;
  public $soyad;
  public function _types() {
      return [
      'ad' => 'string',
      'soyad' => 'string',
      'kgnblg' => 'array&integer',
      'asdasdasd' => 'integer',
      'haha' => 'ReflectionOrnekClass\Urun',
      'kagan' => 'integer&enum&ReflectionOrnekClass\Candidates',
      'ad' => 'string',
      'soyad' => 'string',
      ];
  }
}
?>
