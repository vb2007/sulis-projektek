<?php
//1.
$szamok = [1, 5, 8, 17, 25, 34];

//2.
echo count($szamok) . " elem található a tömbben.\n";

//3.
$elsoKulcs = array_key_first($szamok);
$utolsoKolcs = array_key_last($szamok);

echo "Első szám: $szamok[$elsoKulcs]\n";
echo "Utolsó szám: $szamok[$utolsoKolcs]\n";

//4.
for ($i = 0; $i < count($szamok); $i++) {
    echo $szamok[$i];
    if ($i < count($szamok) - 1) {
        echo ", ";
    }
}
echo "\n";

//5.
$parosSzamok = [];
foreach ($szamok as $i => $j) {
    if ($j % 2 == 00) {
        $parosSzamok[] = $j;
    }
}
echo implode(", ", $parosSzamok) . "\n";

//6.
for ($i = count($szamok) - 1; $i >= 0; $i--) {
    echo $szamok[$i];
    if ($i > 0) {
        echo ", ";
    }
}
echo "\n";

//7.
echo "Számok összege: " . array_sum($szamok) . "\n";

//8.
$szurtSzamok = array_filter($szamok);
$atlag = array_sum($szurtSzamok) / count($szurtSzamok);
echo "Számok átlaga: $atlag\n";
