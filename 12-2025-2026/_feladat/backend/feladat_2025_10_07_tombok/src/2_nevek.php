<?php
//1.
$nevek = ["Robert Downey Jr.", "Chris Hemsworth", "Scarlett Johansson", "Karen Gillan", "Benedict Cumberbatch"];

//2.
echo "2. feladat\n";
echo "Első: $nevek[0]\n";

//3,
$utolsoKolcs = array_key_last($nevek);
echo "3 .feladat\n";
echo "Utolsó: $nevek[$utolsoKolcs]\n";

//4.
echo "4. feladat\n";
for ($i = 0; $i < count($nevek); $i++) {
    echo "- $nevek[$i]\n";
}
