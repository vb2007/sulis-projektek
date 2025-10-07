<?php
//1.
$szamok = [1, 5, 8, 17, 25, 34];

//2.
echo count($szamok) . " elem található a tömbben.\n";

//3.
echo "Első szám: " . array_key_first($szamok) . "\n";
echo "Utolsó szám: " . array_key_last($szamok) . "\n";

//4.
for ($i = 0; $i < count($szamok); $i++) {
    echo $szamok[$i];
    if ($i < count($szamok) - 1) {
        echo ", ";
    }
}
echo "\n";

//5.
foreach ($szamok as $i => $j) {
    if ($j % 2 == 00) {
        echo $j . " ";
    }
}
echo "\n";
