<?php

require "data.php";

if ($argc > 2) {
    echo "Túl sok paraméter!\n";
    exit(5);
}

if ($argc == 1) {
    for ($i = 0; $i < count($dodgeball); $i += 2) {
        echo $dodgeball[$i] . " -> " . $dodgeball[$i + 1] . "\n";
    }

    exit;
}

switch ($argv[1]) {
    case "kidobok":
        $kidobok = [];
        for ($i = 0; $i < count($dodgeball); $i += 2) {
            $kidobok[] = $dodgeball[$i];
        }

        echo implode(", ", $kidobok) . "\n";

        break;
    case "dobasok":
        #ha tényleg mindig páros az array, ahogy a feladat írta
        echo count($dodgeball) / 2 . "\n";

        break;
    case "unlucky":
        echo "Elsőnek " . $dodgeball[0] . " dobta ki " . $dodgeball[1] . " játékost!\n";

        break;
    case "karma":
        $kidobok = [];
        $karma = [];

        for ($i = 0; $i < count($dodgeball); $i += 2) {
            $kidobok[] = $dodgeball[$i];
        }

        for ($i = 1; $i < count($dodgeball); $i += 2) {
            #"!in_array($kidobott, $karma)" a duplikáltak elkerülésére
            $kidobott = $dodgeball[$i];
            if (in_array($kidobott, $kidobok) && !in_array($kidobott, $karma)) {
                $karma[] = $kidobott;
            }
        }

        foreach ($karma as $jatekos) {
            echo "- " . $jatekos . "\n";
        }

        break;
    default:
        echo "Ismeretlen paraméter!\n";
        exit(10);
}
