<?php
declare(strict_types=1);
error_reporting(E_ALL);

require __DIR__ . "/vendor/autoload.php";

use RealEstate\Rental\Office;

$whoops = new \Whoops\Run();
$whoops->pushHandler(new \Whoops\Handler\PrettyPageHandler());
$whoops->register();

ob_start();

$offices = [];
$file = file_get_contents(__DIR__ . "/data.csv");
$lines = explode("\n", $file);

for ($i = 1; $i < count($lines); $i++) {
    if ("" != $lines[$i]) {
        $split = explode(";", $lines[$i]);
        array_push($offices, new Office((int) $split[0], $split[1], $split[2], (int) $split[3], (float) $split[4]));
    }
}

usort($offices, fn($a, $b) => strcmp($a->name, $b->name));

$title = "";
$action = "";
$load = "";
if (!isset($_GET["action"])) {
    $title = "Irodák";
    $action = "table";
    $load = "table.php";
} else {
    $action = $_GET["action"];

    switch ($action) {
        case "show":
            $id = isset($_GET["id"]) ? (int) $_GET["id"] : 0;
            $office = null;
            foreach ($offices as $o) {
                if ($o->id === $id) {
                    $office = $o;
                    break;
                }
            }
            if ($office === null) {
                $title = "404";
                $load = "404.php";
                header("HTTP/1.1 404 Not Found");
            } else {
                $title = $office->name;
                $load = "show.php";
            }
            break;

        case "create":
            $title = "Új iroda";
            $load = "create.php";
            $data = ["name" => "", "address" => "", "price" => "", "rooms" => ""];
            $errors = [];

            if ($_SERVER["REQUEST_METHOD"] === "POST") {
                $data = [
                    "name" => $_POST["name"] ?? "",
                    "address" => $_POST["address"] ?? "",
                    "price" => $_POST["price"] ?? "",
                    "rooms" => $_POST["rooms"] ?? "",
                ];

                if (trim($data["name"]) === "") {
                    $errors["name"] = "A név megadása kötelező!";
                }
                if (trim($data["address"]) === "") {
                    $errors["address"] = "A cím megadása kötelező!";
                }
                if ($data["price"] === "") {
                    $errors["price"] = "Az ár megadása kötelező!";
                } elseif ((int) $data["price"] < 100000) {
                    $errors["price"] = "Egy iroda bérlése minimum 100 000 Ft-ba kerül!";
                }
                if ($data["rooms"] === "") {
                    $errors["rooms"] = "A szobaszám megadása kötelező!";
                } elseif ((float) $data["rooms"] <= 0) {
                    $errors["rooms"] = "A szobaszám nem lehet nulla, vagy annál kevesebb!";
                }

                if (empty($errors)) {
                    $maxId = 0;
                    foreach ($offices as $o) {
                        if ($o->id > $maxId) {
                            $maxId = $o->id;
                        }
                    }
                    $newId = $maxId + 1;
                    $line = implode(";", [$newId, $data["name"], $data["address"], $data["price"], $data["rooms"]]);
                    file_put_contents(__DIR__ . "/data.csv", "\n" . $line, FILE_APPEND);
                    header("Location: index.php");
                    exit();
                }
            }
            break;

        default:
            $title = "404";
            $load = "404.php";
            header("HTTP/1.1 404 Not Found");
            break;
    }
}

$menuItems = [
    [
        "text" => "Főoldal",
        "url" => "index.php",
        "active" => $action == "table",
    ],
    [
        "text" => "Új iroda",
        "url" => "index.php?action=create",
        "active" => $action == "create",
    ],
];
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="https://cdn.jsdelivr.net/npm/@tailwindcss/browser@4"></script>
    <title><?= $title ?></title>
</head>
<body class="min-h-screen flex flex-col">
    <?php include __DIR__ . "/components/menu.php"; ?>
    <?php include __DIR__ . "/pages/" . $load; ?>
</body>
</html>

<?php ob_end_flush();
