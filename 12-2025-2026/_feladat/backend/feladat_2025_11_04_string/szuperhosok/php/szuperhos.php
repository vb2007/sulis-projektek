<?php

$hero = $argv[1];

echo "2. feladat:\n";
echo "Hős neve:\t" . strtoupper($hero) . "\n"; //mb_strtoupper

echo "3. feladat:\n";
echo "Hős karaktereinek száma: " . strlen($hero) . "\n"; //mb_strlen

echo "4. feladat:\n";
echo "A hősnek " . ($argc > 2 ? "van" : "nincs") . " társa.\n";

echo "5. feladat:\n";
echo "A hős nevében " . (str_contains($hero, "man") ? "szerepel" : "nem szerepel") . " a 'man' angol szó.\n";
