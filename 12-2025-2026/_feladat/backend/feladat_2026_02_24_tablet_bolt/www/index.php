<?php

declare(strict_types=1);
error_reporting(E_ALL);

require __DIR__ . "/vendor/autoload.php";

$whoops = new \Whoops\Run();
$whoops->pushHandler(new \Whoops\Handler\PrettyPageHandler());
$whoops->register();

$page = "home";

if (!empty($_GET["page"])) {
    $page = $_GET["page"];
}

if ($page !== "table" && $page !== "grid") {
    $page = "404";
}

$menuItems = [
    [
        "text" => "Főoldal",
        "url" => "index.php",
        "active" => $page === "home",
    ],
    [
        "text" => "Táblázat",
        "url" => "index.php?page=table",
        "active" => $page === "table",
    ],
    [
        "text" => "Rács",
        "url" => "index.php?page=grid",
        "active" => $page === "grid",
    ],
];

require __DIR__ . "/data.php";

switch ($page) {
    //ár szerint növekvő
    case "table":
        usort(
            $tablets,
            fn(
                $a,
                $b, //arrown function, simánál return kellene
            ) => $a->price <=> $b->price,
        );
        break;

    //ár szerint csökkenő
    case "grid":
        usort($tablets, fn($a, $b) => $b->price <=> $a->price);
        break;

    case "404":
        header("HTTP/1.0 404 Not Found");
        break;
}

$title = "Tabletek: " . count($tablets) . " darab";
?>

<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title><?= $title ?></title>
    <script src="https://cdn.tailwindcss.com"></script>
</head>
<body class="min-h-screen flex flex-col">
    <?php include __DIR__ . "/components/menu.php"; ?>

    <?php
    $pageFile = __DIR__ . "/pages/" . $page . ".php";
    if (file_exists($pageFile)) {
        include $pageFile;
    }
    ?>

    <?php include __DIR__ . "/components/footer.php"; ?>
</body>
</html>