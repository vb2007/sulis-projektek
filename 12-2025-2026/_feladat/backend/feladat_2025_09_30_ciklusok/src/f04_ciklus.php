<?php

$a = $argv[1];
$b = $argv[2];

if ($a > $b) {
    $i = $a;
    while ($i >= $b) {
        if ($i % 2 != 0) {
            echo "$i\n";
        }
        $i--;
    }
} else {
    $i = $a;
    while ($i <= $b) {
        if ($i % 2 != 0) {
            echo "$i\n";
        }
        $i++;
    }
}
