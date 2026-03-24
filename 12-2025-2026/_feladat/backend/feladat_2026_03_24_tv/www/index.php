<?php

error_reporting(E_ALL);

require __DIR__ . "/vendor/autoload.php";
require __DIR__ . "/data.php";

$whoops = new \Whoops\Run();
$whoops->pushHandler(new \Whoops\Handler\PrettyPageHandler());
$whoops->register();

$page = "home";
if (!empty($_GET["page"])) {
    $page = $_GET["page"];
    if ($page !== "seller" && $page !== "products") {
        $page = "404";
    }
}

$menuItems = [
    [
        "text" => "Főoldal",
        "url" => "index.php",
        "active" => $page === "home",
    ],
    [
        "text" => "Eladói oldal",
        "url" => "index.php?page=seller",
        "active" => $page === "seller",
    ],
    [
        "text" => "Termékek",
        "url" => "index.php?page=products",
        "active" => $page === "products",
    ],
];


?>

<!doctype html>
<html lang="hu">
    <head>
        <meta charset="UTF-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <title><?= $title ?></title>
        <link rel="stylesheet" href="css/tv.css" />
        <script src="https://cdn.jsdelivr.net/npm/@tailwindcss/browser@4"></script>
    </head>

    <body>
    </body>

</html>
