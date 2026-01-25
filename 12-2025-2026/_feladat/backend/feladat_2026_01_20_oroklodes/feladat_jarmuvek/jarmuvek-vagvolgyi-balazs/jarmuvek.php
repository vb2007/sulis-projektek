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
