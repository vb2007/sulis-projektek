<?php

$a = (float) $argv[1];
$b = (float) $argv[2];
$c = (float) $argv[3];

if ($a + $b < $c) {
    echo "A háromszög nem szerkeszthető meg\n";
    return;
}

if ($b + $c < $a) {
    echo "A háromszög nem szerkeszthető meg\n";
    return;
}

if ($a + $c < $b) {
    echo "A háromszög nem szerkeszthető meg\n";
    return;
}

$k = $a + $b + $c;
$s = $k / 2;
$t = round(sqrt($s * ($s - $a) * ($s - $b) * ($s - $c)), 3);

echo "T=$t\n";
echo "K=$k\n";
