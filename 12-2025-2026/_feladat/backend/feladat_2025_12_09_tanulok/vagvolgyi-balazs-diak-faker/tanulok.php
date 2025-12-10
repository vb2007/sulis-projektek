 <?php

require __DIR__ . "/vendor/autoload.php";

use Neu\Iskola\Diak;
use Faker\Factory;

if ($argc < 2) {
    echo "A szkriptnek nem lett megadva a kimeneti fájl neve!" . PHP_EOL;
    exit(1);
}

$outputFile = $argv[1];
if (!str_ends_with($outputFile, ".txt") && !str_ends_with($outputFile, ".csv")) {
    echo "A kimeneti fájl kiterjesztése csak `txt` vagy `csv` lehet!" . PHP_EOL;
    exit(2);
}

$recordCount = 1;
if (isset($argv[2])) {
   if (!is_numeric($argv[2]) || intval($argv[2]) < 1) {
      echo "Amennyiben a második paraméter kitöltésre kerül, úgy az minimum 1 legyen" . PHP_EOL;
      exit(3);
   }

    $recordCount = intval($argv[2]);
}

$faker = Factory::create("hu_HU");

$diakok = [];
for ($i = 0; $i < $recordCount; $i++) {
    $vnev = $faker->lastName;
    $knev = $faker->firstName;
    $email = $faker->email;
    $szuletett = $faker->dateTimeBetween("-30 years", "-10 years");

    $diakok[] = new Diak($vnev, $knev, $email, $szuletett);
}

$outputPath = __DIR__ . "/out/" . $outputFile;

if (str_ends_with($outputFile, ".txt")) {
    $content = "";
    foreach ($diakok as $diak) {
        $content .= $diak->sorszam . PHP_EOL;
        $content .= $diak->teljes_nev . PHP_EOL;
        $content .= $diak->email . PHP_EOL;
        $content .= $diak->szuletett_iso . PHP_EOL;
    }
    file_put_contents($outputPath, $content);
} else { //csak .csv lehet
    $fp = fopen($outputPath, 'w');
    foreach ($diakok as $diak) {
        fputcsv($fp, [
            $diak->sorszam,
            $diak->teljes_nev,
            $diak->email,
            $diak->szuletett_iso
        ], ';');
    }
    fclose($fp);
}

echo "Adatok kiírva: out/$outputFile" . PHP_EOL;
