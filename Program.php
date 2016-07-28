<?php
/**
 * Created by PhpStorm.
 * User: KGN
 * Date: 22.07.2016
 * Time: 15:31
 */

namespace Account;
include_once 'Users.php';
include_once 'Role.php';
include_once 'Adress.php';
include_once 'Master.php';
include_once 'Candidates.php';

$users = new Users([
        'ad' => 'Mehmet',
        'soyad' => 'OK',
        'telefonNo' => 12345,
        'adress' => new Adress(),
        'role' => [
            new Role(),
            new Role(),
            new Role()
        ],
        'test' => [
            'a' => 1,
            'b' => 2
        ],
        'enum' => 2
    ]);

print_r(get_object_vars($users));

echo "<br />";

echo gettype(get_object_vars($users)["test"]);

echo "<br>";

$users->validateVariables();