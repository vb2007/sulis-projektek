<?php
declare(strict_types=1);

require __DIR__ . "/vendor/autoload.php";

use Acme\Kozlekedes\Auto;
use Acme\Kozlekedes\Busz;
use Acme\Kozlekedes\Roller;

if ($argc > 3) {
    echo "Túl sok paraméter!";
    exit(271);
}

$type = $argv[0];
$acceptedTypes = ["auto", "busz", "roller"];
if (!in_array(strtolower($type), $acceptedTypes)) {
    echo "Érvénytelen járműtípus!";
    exit(271);
}

$output = $argv[1];
if (!str_ends_with(".csv", $output)) {
    echo "Érvénytelen kimeneti fájlkiterjesztés, csak a .csv elfogadott!";
    exit(271);
}
