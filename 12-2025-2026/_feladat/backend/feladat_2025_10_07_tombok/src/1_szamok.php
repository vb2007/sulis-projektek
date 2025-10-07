<?php
//1.
$szamok = [1, 5, 8, 17, 25, 34];

//2.
echo "2. feladat\n";
echo count($szamok) . "\n\n";

//3.
echo "3. feladat\n";
$elsoKulcs = array_key_first($szamok);
$utolsoKolcs = array_key_last($szamok);

echo "Első szám: $szamok[$elsoKulcs]\n";
echo "Utolsó szám: $szamok[$utolsoKolcs]\n\n";

//4.
echo "4. feladat\n";
for ($i = 0; $i < count($szamok); $i++) {
    echo $szamok[$i];
    if ($i < count($szamok) - 1) {
        echo ", ";
    }
}
echo "\n\n";

//5.
echo "5. feladat\n";
$parosSzamok = [];
foreach ($szamok as $i => $j) {
    if ($j % 2 == 00) {
        $parosSzamok[] = $j;
    }
}
echo implode(", ", $parosSzamok) . "\n\n";

//6.
echo "6. feladat\n";
for ($i = count($szamok) - 1; $i >= 0; $i--) {
    echo $szamok[$i];
    if ($i > 0) {
        echo ", ";
    }
}
echo "\n\n";

//7.
echo "7. feladat\n";
echo array_sum($szamok) . "\n\n";

//8.
echo "8. feladat\n";
$szurtSzamok = array_filter($szamok);
$atlag = array_sum($szurtSzamok) / count($szurtSzamok);
echo "$atlag\n";
