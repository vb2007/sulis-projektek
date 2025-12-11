<?php

require __DIR__ . "/vendor/autoload.php";

use Acme\Vehicles\Train;
use Faker\Factory;

// $train = new Train(3, "ic", "MÁV");
// echo "Number: " . $train->number . PHP_EOL;
// echo "Type: " . $train->type . PHP_EOL;
// echo "Old operator: " . $train->operator . PHP_EOL;
// $train->operator = "GYSEV";
// echo "New operator: " . $train->operator . PHP_EOL;

$faker = Factory::create();

$trains = [];

for ($i = 0; $i < 100; $i++) {
   $train = new Train(
      $faker->numberBetween(1, 9999),
      $faker->randomElement(["rjx", "ec", "en", "ic", "ir", "s", "gy", "sz"]),
      $faker->randomElement(["MÁV", "ÖBB", "CD", "ZSSK", "GYSEV"])
   );

   array_push($trains, $train);
}

$file = fopen("out/tains.txt", "w");
fwrite($file, "type\tnumber\toperator" . PHP_EOL);

foreach ($trains as $train) {
   fwrite($file, $train . PHP_EOL);
}

fclose($file);
