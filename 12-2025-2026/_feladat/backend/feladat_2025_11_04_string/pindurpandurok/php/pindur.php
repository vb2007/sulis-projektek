<?php

$pp = [
    "sziporka" => "Blossom",
    "puszedli" => "Bubbles",
    "csuporka" => "Buttercup",
    "pukkancs" => "Bliss",
    "nyuszi" => "Bunny"
];

echo "Pindúr Pandúrok (The Powerpuff Girls)\n";

$angolnevek = explode(";", $argv[1]);
foreach ($angolnevek as $nev) {
    echo $pp[strtolower($nev)] . "\n";
}
