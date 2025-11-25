<?php

declare(strict_types=1);

require "src/Space/Exploration/Alien.php";

use Space\Exploration\Alien;

$alien1 = new Alien("Zog", "Zogonia", true);
$alien2 = new Alien("Blip", "Blipton", false);
$alien3 = new Alien("Xar", "Xarax", true);
$alien4 = new Alien("Gloop", "Gloopia", false);

$aliens = [$alien1, $alien2, $alien3, $alien4];

foreach($aliens as $alien) {
    echo ($alien->isFriendly() ? " " : "!") . $alien->getSpecies() . " (" . $alien->getPlanet() . ")" . PHP_EOL;
}
