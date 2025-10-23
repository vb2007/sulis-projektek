<?php

require "fuggvenyek.php";

$kmLegutobbiTankolas = $argv[1];
$kmJelenleg = $argv[2];
$jelenlegiTankolas = $argv[3];

$km = $kmJelenleg - $kmLegutobbiTankolas;
$atlagFogyasztas = fogyasztas($km, $jelenlegiTankolas);

echo "Előző óraállás: " . number_format($kmLegutobbiTankolas, 0, ".", " ") . " km\n";
echo "Mostani óraállás: " . number_format($kmJelenleg, 0, ".", " ") . " km\n";
echo "Megtett út: " . number_format($km, 0, ".", " ") . " km\n";
echo "Tankolt üzemanyag: {$jelenlegiTankolas} liter\n";
echo "Átlagfogyasztás: {$atlagFogyasztas} liter/100km\n";
