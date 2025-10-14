<?php

require "jaratok.php";

if ($argc > 2) {
    echo "Túl sok paraméter!";
    exit(4);
}

if ($argc == 1) {
    foreach ($jaratok as $jaratszam => $adat) {
        echo "{$jaratszam}\t{$adat['honnan']}-{$adat['hova']}\t{$adat['indul']}-{$adat['erkezik']}\n";
    }
}
