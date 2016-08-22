<?php
/**
 * Created by PhpStorm.
 * User: KGN
 * Date: 29.07.2016
 * Time: 15:35
 */

namespace Account;
include_once 'Role.php';
include_once 'Candidates.php';
include_once 'Users.php';

class ValidateTest extends \PHPUnit_Framework_TestCase
{

    public function testGetType()
    {
        $testData = "kaganbalga";
        $tester = new Validate();

        $comingResult = $tester->getType($testData);

        $this->assertEquals("string", $comingResult);
    }

    public function testValidateVariables()
    {
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

        $users->validateVariables();

        $this->expectOutputString('');
    }

    public function testSingleValidateArrays()
    {
        $tester = new Validate();
        $tester->validateArrays(array(0, 1, 2),"integer");

        $this->expectOutputString('');
    }

    public function testValidateMultipleArrays()
    {
        $tester = new Validate();
        $tester->validateMultipleArrays(array([
            'asd' => 'kgn',
            'abc' => 'qwe'
        ]), "string", "string");

        $this->expectOutputString('');
    }

    public function testValidateEnum()
    {
        $tester = new Validate();
        $tester->validateEnum(2, '\Account\Candidates');

        $this->expectOutputString('');
    }
}
?>