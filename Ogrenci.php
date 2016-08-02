<?php

namespace ReflectionOrnekClass;
include_once 'modelclass.php';

class Ogrenci extends Model
{
  public $ad;
  public $soyad;
  public $kgnblg;
  public $asdasdasd;
  public $listeys;
  public $zgn;
  public $testlist;
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
      'listeys' => 'array&single&string',
      'zgn' => 'array&string&integer',
      'testlist' => 'array&single&integer',
      'haha' => 'ReflectionOrnekClass\Urun',
      'kagan' => 'integer&enum&ReflectionOrnekClass\Candidates',
      'ad' => 'string',
      'soyad' => 'string',
      ];
  }
}
?>
  }
}
?>
  }
}
?>
