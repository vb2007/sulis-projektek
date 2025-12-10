 <?php

require __DIR__ . "/vendor/autoload.php";

use Neu\Iskola\Diak;

if ($argc != 2) {
    echo "A szkriptnek nem lett megadva a kimeneti fájl neve" . PHP_EOL;
    exit(1);
}

$outputFile = $argv[1];
if (!str_ends_with($outputFile, ".txt") && !str_ends_with($outputFile, ".csv")) {
    echo "A kimeneti fájl kiterjesztése csak `txt` vagy `csv` lehet!" . PHP_EOL;
    exit(2);
}

$recordCount = 0;
switch ($argv[2]) {
   case $argv[2] <= 0:
   case !is_int($argv[2]):
      echo "Amennyiben a második paraméter kitöltésre kerül, úgy az minimum 1 legyen" . PHP_EOL;
      exit(3);
   case null:
      $recordCount = 1;
      break;
}
