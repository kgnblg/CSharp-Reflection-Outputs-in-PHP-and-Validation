<?php
/**
 * Created by PhpStorm.
 * User: KGN
 * Date: 22.07.2016
 * Time: 15:29
 */

namespace Account;

include 'Validate.php';
include_once 'Adress.php';
include_once 'Role.php';

class Users extends Validate
{
    public $ad;
    public $soyad;
    public $telefonNo;
    public $adress;
    public $role;
    public $test = array();
    public $enum;

    public function _types()
    {
        return array([
            'ad' => 'string',
            'soyad' => 'string',
            'telefonNo' => 'integer',
            'adress' => 'Account\Adress',
            'role' => 'array&Account\Role',
            'test' => 'array',
            'enum' => 'integer&enum&\Account\Candidates',
        ]);
    }
}
?>




