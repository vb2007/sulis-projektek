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

$count = (int)$argv[1];
$iceCreams = [];
$availableFlavours = IceCream::availableFlavours();

for ($i = 0; $i < $count; $i++) {
    $scoop = $faker->numberBetween(1, 5);
    $sweetCone = $faker->boolean();
    $iceCream = new IceCream($scoop, $sweetCone);

    $selectedFlavours = [];
    for ($j = 0; $j < $scoop; $j++) {
        $selectedFlavours[] = $faker->randomElement($availableFlavours);
    }
    $iceCream->flavours = $selectedFlavours;

    $iceCreams[] = $iceCream;
}

foreach ($iceCreams as $iceCream) {
    echo $iceCream . PHP_EOL;
}

$csvPath = __DIR__ . "/out/sale.csv";
$file = fopen($csvPath, "w");

foreach ($iceCreams as $iceCream) {
    $originalPrice = $iceCream->price;
    $discountedPrice = (int)round($originalPrice * 0.9);
    $iceCream->price = $discountedPrice;
    $coneText = $iceCream->sweetCone ? "édes" : "normál";
    $flavoursText = implode(", ", $iceCream->flavours);

    $line = sprintf(
        '%d;%d;"%s";"%s"%s',
        $iceCream->scoop,
        $iceCream->price,
        $coneText,
        $flavoursText,
        PHP_EOL
    );

    fwrite($file, $line);
}

fclose($file);
