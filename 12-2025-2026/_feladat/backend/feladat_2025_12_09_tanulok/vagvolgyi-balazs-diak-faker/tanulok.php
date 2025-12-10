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
