<?php

require __DIR__ . "/vendor/autoload.php";

use Acme\Vehicles\Train;
use Faker\Factory;

$train = new Train(3, "ic", "MÁV");
echo "Number: " . $train->number . PHP_EOL;
echo "Type: " . $train->type . PHP_EOL;
echo "Old operator: " . $train->operator . PHP_EOL;
$train->operator = "GYSEV";
echo "New operator: " . $train->operator . PHP_EOL;
