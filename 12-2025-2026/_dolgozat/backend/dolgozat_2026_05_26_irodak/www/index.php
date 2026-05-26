<?php
declare(strict_types=1);

require __DIR__ . "/vendor/autoload.php";

$whoops = new \Whoops\Run;
$whoops->pushHandler(new \Whoops\Handler\PrettyPageHandler);
$whoops->register();

ob_start();

$offices = [];
$file = file_get_contents(__DIR__ . "/data.csv");
$lines = explode("\n", $file);

for ($i = 1; $i < count($lines); $i++) {
    if ("" != $lines[$i]) {
        $split = explode(";", $lines[$i]);
        array_push($offices, new Office(
            (int) $split[0],
            $split[1],
            $split[2],
            (int) $split[3],
            (float) $split[4]
        ));
    }
}


?>

<?php
ob_end_flush();