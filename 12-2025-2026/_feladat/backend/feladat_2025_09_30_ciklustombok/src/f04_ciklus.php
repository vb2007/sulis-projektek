<?php

$a = $argv[1];
$b = $argv[2];

if ($a > $b) {
    while ($b > $a) {
        echo "$b\n";
        $b++;
    }
}
else {
    while ($a < $b) {
        echo "$a\n";
        $a++;
    }
}
