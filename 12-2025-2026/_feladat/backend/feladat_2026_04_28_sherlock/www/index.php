<?php

error_reporting(E_ALL);

require __DIR__ . "/vendor/autoload.php";
require __DIR__ . "/data/data.php";

$whoops = new \Whoops\Run();
$whoops->pushHandler(new \Whoops\Handler\PrettyPageHandler());
$whoops->register();

$action = "home";
$title = "Sherlock epizódok";
if (!empty($_GET["action"])) {
    $action = $_GET["action"];
    if ($action != "create") {
        $action = "404";
        $title = "404";
        header("HTTP/1.0 404 Not Found");
    }
}

$menuItems = [
    [
        "text" => "Főoldal",
        "url" => "index.php",
        "active" => $action == "home",
    ],
    [
        "text" => "Új epizód",
        "url" => "index.php?action=create",
        "active" => $action == "create",
    ],
];
?>

<!DOCTYPE html>
<html lang="hu">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title><?= $title ?></title>
    <link rel="stylesheet" href="css/tv.css">
    <script src="https://cdn.jsdelivr.net/npm/@tailwindcss/browser@4"></script>
</head>

<body class="min-h-screen flex flex-col">

</body>

</html>
