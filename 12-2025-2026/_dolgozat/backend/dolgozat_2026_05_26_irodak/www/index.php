<?php
declare(strict_types=1);
error_reporting(E_ALL);

require __DIR__ . "/vendor/autoload.php";

use RealEstate\Rental\Office;

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

$title = "";
$action = "";
if(!isset($_GET["action"])) {
    $title = "Irodák";
    include __DIR__ . "/pages/table.php";
}
else {
    $action = $_GET["action"];

    switch ($action) {
        case "show":
            $id = $_GET["id"];
            $title = "Irodák"; //TODO: iroda neve
            include __DIR__ . "/pages/show.php"; //TODO: query param
            break;

        case "create":
            $title = "Új iroda";
            include __DIR__ . "/pages/create.php";
            break;

        default:
            $title = "404";
            include __DIR__ . "/pages/404.php";
            break;
    }
}

$menuItems = [
    [
        "text" => "Főoldal",
        "url" => "index.php",
        "active" => ""
    ],
    [
        "text" => "Új iroda",
        "url" => "index.php?action=create",
        "active" => ""
    ]
];

?>

<?php
ob_end_flush();