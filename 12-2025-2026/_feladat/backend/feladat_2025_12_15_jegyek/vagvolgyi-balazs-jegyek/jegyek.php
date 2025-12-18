<?php
declare(strict_types=1);

require __DIR__ . "/vendor/autoload.php";

use Faker\Factory;
use Acme\Iskola\Jegy;

$faker = Factory::create("hu_HU");

if ($argc < 3) {
    echo "Az első két paraméter megadása kötelező!" . PHP_EOL;
    exit(3);
}

$tipus = $argv[1];
if ($tipus != "busz" && $tipus != "mozi" && $tipus != "osztalyzat" && $tipus != "repulo") {
    echo "Nem megfelelő paraméter!" . PHP_EOL;
    echo "Az első paraméter csak 'busz', 'mozi', 'osztalyzat' vagy 'repulo' lehet!" . PHP_EOL;
    exit(7);
}

if (!is_int($argv[2]) && intval($argv[2]) < 1) {
    echo "Nem megfelelő paraméter!" . PHP_EOL;
    echo "A második paraméternek 0-nál nagyobb számnak kell lennie!" . PHP_EOL;
    exit(2);
}
$darabszam = $argv[2];

$kimenet = null;
if (isset($argv[3])) {
    if ($argv[3] !== "csv" && $argv[3] !== "json") {
        echo "Nem megfelelő paraméter!" . PHP_EOL;
        echo "A harmadik paraméter csak 'csv' vagy 'json' lehet amennyiben meg lett adva!" . PHP_EOL;
        exit(9);
    }

    $kimenet = $argv[3];
}

$jegyek = [];

if ($tipus == "osztalyzat") {
    for ($i = 0; $i < $darabszam; $i++) {
        $jegy = new Jegy(
            $faker->randomElement(Jegy::lehetsegesTipusok()),
            $faker->numberBetween(1, 5),
            $faker->randomElement(Jegy::lehetsegesTantargyak()),
            $faker->name(),
            $faker->dateTimeBetween('-2 weeks', 'now')
        );

        $jegyek[] = $jegy;
    }
}
