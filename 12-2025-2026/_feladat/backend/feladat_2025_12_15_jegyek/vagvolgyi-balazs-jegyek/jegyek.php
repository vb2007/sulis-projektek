<?php
declare(strict_types=1);

require __DIR__ . "/vendor/autoload.php";

use Faker\Factory;
use Acme\Iskola\Jegy as IskolaJegy;
use Acme\Mozi\Jegy as MoziJegy;

$faker = Factory::create("hu_HU");

if ($argc < 3) {
    echo "Az első két paraméter megadása kötelező!" . PHP_EOL;
    exit(3);
}

$tipus = $argv[1];
if ($tipus != "busz" && $tipus != "mozi" && $tipus != "osztalyzat" && $tipus != "repulo") {
    echo "Nem megfelelő paraméter!" . PHP_EOL;
    echo "Az első paraméter csak 'busz', 'mozi', 'osztalyzat' vagy 'repulo' lehet!" . PHP_EOL;
    exit(7);
}

if (!is_int($argv[2]) && intval($argv[2]) < 1) {
    echo "Nem megfelelő paraméter!" . PHP_EOL;
    echo "A második paraméternek 0-nál nagyobb számnak kell lennie!" . PHP_EOL;
    exit(2);
}
$darabszam = $argv[2];

$kimenet = null;
if (isset($argv[3])) {
    if ($argv[3] !== "csv" && $argv[3] !== "json") {
        echo "Nem megfelelő paraméter!" . PHP_EOL;
        echo "A harmadik paraméter csak 'csv' vagy 'json' lehet amennyiben meg lett adva!" . PHP_EOL;
        exit(9);
    }

    $kimenet = $argv[3];
}

$jegyek = [];

if ($tipus == "osztalyzat") {
    for ($i = 0; $i < $darabszam; $i++) {
        $jegy = new IskolaJegy(
            $faker->randomElement(IskolaJegy::lehetsegesTipusok()),
            $faker->numberBetween(1, 5),
            $faker->randomElement(IskolaJegy::lehetsegesTantargyak()),
            $faker->name(),
            $faker->dateTimeBetween('-2 weeks', 'now')
        );

        $jegyek[] = $jegy;
    }
}

if ($tipus == "mozi") {
    for ($i = 0; $i < $darabszam; $i++) {
        $jegy = new MoziJegy(
            $faker->text(40),
            $faker->numberBetween(1, 20) * 1000 - 10,
            $faker->randomElement(MoziJegy::termekNevei()),
            strtoupper($faker->randomLetter()),
            $faker->numberBetween(1, 60),
            $faker->dateTimeBetween('tomorrow', '+30 days'),
            $faker->boolean()
        );

        $jegyek[] = $jegy;
    }
}

$outputPath = __DIR__ . "/out/" . ($tipus == "osztalyzat" ? "osztalyzatok" : "mozijegyek") . "." . $kimenet;
switch ($kimenet) {
    case null:
        foreach ($jegyek as $jegy) {
            echo $jegy . PHP_EOL;
        }

        break;
    case "csv":
        $fp = fopen($outputPath, 'w');

        if ($tipus == "osztalyzat") {
            fputcsv($fp, ['tipus', 'jegy', 'osztalyzat', 'tantargy', 'tanar', 'beirva'], ',', '"', '');
        } elseif ($tipus == "mozi") {
            fputcsv($fp, ['cim', 'ar', 'terem', 'sor', 'ules', 'kezdes', 'korhataros'], ',', '"', '');
        }

        foreach ($jegyek as $jegy) {
            $data = $jegy->toArray(true);

            if ($tipus == "osztalyzat") {
                $data['beirva'] = $data['beirva']->format('Y.m.d H:i');
            } elseif ($tipus == "mozi") {
                $data['kezdes'] = $data['kezdes']->format('Y-m-d H:i');
            }

            fputcsv($fp, $data, ',', '"', '');
        }

        fclose($fp);

        break;
    case "json":
        $jsonData = [];
        foreach ($jegyek as $jegy) {
            $data = $jegy->toArray(true);

            if ($tipus == "osztalyzat") {
                $data['beirva'] = $data['beirva']->format('Y.m.d H:i');
            } elseif ($tipus == "mozi") {
                $data['kezdes'] = $data['kezdes']->format('Y-m-d H:i');
            }

            $jsonData[] = $data;
        }

        file_put_contents($outputPath, json_encode($jsonData, JSON_PRETTY_PRINT | JSON_UNESCAPED_UNICODE));

        break;
}
