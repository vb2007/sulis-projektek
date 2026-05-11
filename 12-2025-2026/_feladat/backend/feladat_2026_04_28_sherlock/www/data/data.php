<?php

use Series\Bbc\Sherlock;

$episodes = [];
$file = file_get_contents("./sherlock.csv");
$lines = explode("\n", $file);

for ($i = 1; $i < count($lines); $i++) {
    if ("" != $lines[$i]) {
        $split = explode("$", $lines[$i]);
        array_push($episodes, new Sherlock($split[0], $split[1], $split[2], $split[3], $split[4], $split[5], $split[6]));
    }
}
