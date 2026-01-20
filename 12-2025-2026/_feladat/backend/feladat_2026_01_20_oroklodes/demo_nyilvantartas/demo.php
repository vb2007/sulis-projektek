<?php
declare(strict_types=1);

require __DIR__ . "/vendor/autoload.php";

use Neu\Nyilvantartas\Dolgozo;
use Neu\Nyilvantartas\Szemely;
use Neu\Nyilvantartas\Tanar;

$szemely = new Szemely("John Pork", DateTime::createFromFormat("Y-m-d", "2002-01-20"));
echo $szemely . PHP_EOL;

$dolgozo = new Dolgozo("Meowl", DateTime::createFromFormat("Y-m-d", "2026-01-01"), 271000);
echo $dolgozo . PHP_EOL;

$tanar = new Tanar("Mező", DateTime::createFromFormat("Y-m-d", "2025-02-02"), 6000000, "22133685");
$tanar->addTantargy("Backend programozás");
$tanar->addTantargy("Frontend programozás");
echo $tanar . PHP_EOL;
