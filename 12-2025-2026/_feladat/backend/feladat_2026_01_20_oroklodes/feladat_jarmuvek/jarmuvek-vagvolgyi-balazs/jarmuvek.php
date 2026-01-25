<?php
declare(strict_types=1);

require __DIR__ . "/vendor/autoload.php";

use Acme\Kozlekedes\Auto;
use Acme\Kozlekedes\Busz;
use Acme\Kozlekedes\Roller;

if ($argc > 3) {
    echo "Túl sok paraméter!" . PHP_EOL;
    exit(271);
}

$type = $argv[1];
$acceptedTypes = ["auto", "busz", "roller"];
if (!in_array(strtolower($type), $acceptedTypes)) {
    echo "Érvénytelen járműtípus!" . PHP_EOL;
    exit(271);
}

$output = $argv[2];
//mi a tökömért kell az in_array-ben első paraméterben $needle-t először, $haystack-et másodszor megadni, a str_ends_with-ben meg fordítva??
if (!str_ends_with($output, ".csv")) {
    echo "Érvénytelen kimeneti fájlkiterjesztés, csak a .csv elfogadott!" . PHP_EOL;
    exit(271);
}

$busz = new Busz("Ikarus", "280", "kék", "diesel", 36);
$auto = new Auto("Tesla", "Model S", "fehér", "elektromos", 5);
$roller1 = new Roller("Oxelo", "C900", "fekete", 2);
$roller2 = new Roller("Blackwheels", "Blink gyerek roller", "színes", 3);

$jarmuvek = [$busz, $auto, $roller1, $roller2];

//"Amennyiben nem kapott a szkript paramétert, úgy a közös adatokat gyarto, tipus, szin jelenítse meg a konzolon."
// a 34-es feladatban meg azt írták, ha nem kap paramétert / helytelen paramétert kap lépjen ki ¯\_(ツ)_/¯
// szóval marad úgy, és helyes paraméterekkel konzolra és fájlba is kiírom

echo "Járművek közös adatai:" . PHP_EOL;
for ($i = 0; $i < count($jarmuvek); $i++) {
    $jarmu = $jarmuvek[$i];
    echo "Gyártó: " . $jarmu->gyarto . ", Típus: " . $jarmu->tipus . ", Szín: " . $jarmu->szin . PHP_EOL;
}
