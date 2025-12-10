 <?php

require __DIR__ . "/vendor/autoload.php";

use Neu\Iskola\Diak;
use Faker\Factory;

if ($argc < 2) {
    echo "A szkriptnek nem lett megadva a kimeneti fájl neve!" . PHP_EOL;
    exit(1);
}

$outputFile = $argv[1];
if (!str_ends_with($outputFile, ".txt") && !str_ends_with($outputFile, ".csv")) {
    echo "A kimeneti fájl kiterjesztése csak `txt` vagy `csv` lehet!" . PHP_EOL;
    exit(2);
}

$recordCount = 1;
if (isset($argv[2])) {
   if (!is_numeric($argv[2]) || intval($argv[2]) < 1) {
      echo "Amennyiben a második paraméter kitöltésre kerül, úgy az minimum 1 legyen" . PHP_EOL;
      exit(3);
   }

    $recordCount = intval($argv[2]);
}

$faker = Factory::create("hu_HU");
