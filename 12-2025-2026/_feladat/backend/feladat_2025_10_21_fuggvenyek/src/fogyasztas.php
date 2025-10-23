<?php

require "fuggvenyek.php";

$kmLegutobbiTankolas = $argv[1];
$kmJelenleg = $argv[2];
$jelenlegiTankolas = $argv[3];

$km = $kmJelenleg - $kmLegutobbiTankolas;
$atlagFogyasztas = fogyasztas($km, $jelenlegiTankolas);

echo "Előző óraállás: {$kmLegutobbiTankolas} km\n";
echo "Mostani óraállás: {$kmJelenleg} km\n";
echo "Megtett út: {$km} km\n";
echo "Tankolt üzemanyag: {$jelenlegiTankolas} liter\n";
echo "Átlagfogyasztás: {$atlagFogyasztas} liter/100km\n";
