<?php
declare(strict_types=1);

require __DIR__ . "/vendor/autoload.php";

use Event\Party\Concert;

$concerts = [];
$file = file_get_contents(__DIR__ . "/concerts.csv");
$lines = explode("\n", $file);

for ($i = 1; $i < count($lines); $i++) {
    if ("" != $lines[$i]) {
        $split = explode(";", $lines[$i]);
        array_push($concerts, new Concert(
            (int) $split[0],
            $split[1],
            $split[2],
            $split[3],
            trim($split[4]),
            (int) $split[5]
        ));
    }
}