<?php
declare(strict_types=1);

require __DIR__ . "/vendor/autoload.php";

use Faker\Factory;
use Acme\Frosty\IceCream;

$faker = Factory::create("hu_HU");

if ($argc < 2) {
    echo "Legalább 1 paraméter megadása szükséges!" . PHP_EOL;
    exit(7);
}

if (!is_numeric($argv[1]) && intval($argv[1]) < 1) {
    echo "Nem megfelelő paraméter!" . PHP_EOL;
    echo "Az első paraméternek 0-nál nagyobb számnak kell lennie!" . PHP_EOL;
    exit(17);
}
