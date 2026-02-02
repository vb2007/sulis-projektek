<?php
declare(strict_types=1);

require __DIR__ . "/vendor/autoload.php";

use Neu\Eszkozok\LezerNyomtato;
use Neu\Eszkozok\TintasugarasNyomtato;
use Neu\Eszkozok\Nyomtato;

function randomGyarto(): string {
    $ref = new ReflectionClass(Nyomtato::class);
    $prop = $ref->getProperty('gyartok');
    $prop->setAccessible(true);
    $gyartok = $prop->getValue();
    return $gyartok[array_rand($gyartok)];
}

$paramSzam = $argc - 1;

if ($paramSzam < 1) {
    echo "Túl kevés paramétert adott meg!" . PHP_EOL;
    exit(7);
}

if ($paramSzam > 2) {
    echo "Túl sok paramétert adott meg!" . PHP_EOL;
    exit(3);
}

$fajta = $argv[1];
if ($fajta !== 'lezer' && $fajta !== 'tintasugaras') {
    echo "Az első paraméter csak 'lezer' vagy 'tintasugaras' lehet!" . PHP_EOL;
    exit(29);
}

$nyomtatok = [];
for ($i = 0; $i < 5; $i++) {
    $gyarto = randomGyarto();
    $tipus = chr(rand(65, 90)) . rand(100, 999);
    $szines = (bool)rand(0, 1);
    $patronVagyTonerSzam = $szines ? 4 : 1;

    if ($fajta === 'tintasugaras') {
        $ar = rand(20000, 250000);
        $nyomtatok[] = new TintasugarasNyomtato(
            $gyarto,
            $tipus,
            $szines,
            $ar,
            $patronVagyTonerSzam
        );
    } else { // lezer
        $ar = rand(40000, 300000);
        $nyomtatok[] = new LezerNyomtato(
            $gyarto,
            $tipus,
            $szines,
            $ar,
            $patronVagyTonerSzam
        );
    }
}

if ($paramSzam === 1) {
    foreach ($nyomtatok as $nyomtato) {
        echo $nyomtato . PHP_EOL;
    }

    exit(0);
}

$masodik = $argv[2];
if ($masodik === 'fajlba') {
    $outDir = __DIR__ . DIRECTORY_SEPARATOR . 'out';

    if (!is_dir($outDir)) {
        mkdir($outDir, 0777, true);
    }

    $fajlNev = $fajta . '.csv';
    $fajlTeljes = $outDir . DIRECTORY_SEPARATOR . $fajlNev;

    $fp = fopen($fajlTeljes, 'w');

    foreach ($nyomtatok as $nyomtato) {
        $sor = $nyomtato->toArray();
        fputcsv($fp, $sor, ';');
    }

    fclose($fp);
    echo "Adatok fájlba írva: $fajlTeljes" . PHP_EOL;
    exit(0);
}

echo "A második paraméter vagy 'fajlba', vagy egy szám legyen!";
exit(2);
