<?php

declare(strict_types=1);

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
            (int) $split[2],
            $split[3],
            $split[4],
            $split[5],
            (float) $split[6]
        ));
    }
}