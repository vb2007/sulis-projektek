<?php
declare(strict_types=1);
error_reporting(E_ALL);

require __DIR__ . "/vendor/autoload.php";

$whoops = new \Whoops\Run;
$whoops->pushHandler(new \Whoops\Handler\PrettyPageHandler);
$whoops->register();

$layout = "home";

if (!empty($_GET['layout'])) {
    $layout = $_GET['layout'];
}

if ($layout !== "home" && $layout !== "table" && $layout !== "grid") {
    $layout = "404";
}

$menuItems = [
    [
        "text" => "Főoldal",
        "url" => "index.php",
        "active" => $layout === "home"
    ],
    [
        "text" => "Táblázat",
        "url" => "index.php?layout=table",
        "active" => $layout === "table"
    ],
    [
        "text" => "Rács",
        "url" => "index.php?layout=grid",
        "active" => $layout === "grid"
    ]
];

require __DIR__ . "/data.php";

if ($layout === "table") {
    usort($horses, function($a, $b) {
        return $b->year <=> $a->year;
    });
}

if ($layout === "grid") {
    usort($horses, function($a, $b) {
        return $a->breed <=> $b->breed;
    });
}

if ($layout === "404") {
    header("HTTP/1.0 404 Not Found");
}

$pageNames = [
    "home" => "felsorolás",
    "table" => "táblázat",
    "grid" => "rács",
    "404" => "404"
];

$title = "Az USA államainak nemzeti lovai (" . $pageNames[$layout] . ")";
?>

<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title><?= $title ?></title>
    <script src="https://cdn.tailwindcss.com"></script>
</head>
<body class="min-h-screen bg-gray-50 flex flex-col">
    <?php include __DIR__ . "/components/menu.php"; ?>

    <?php
    $pageFile = __DIR__ . "/page/" . ($layout === "home" ? "list" : $layout) . ".php";
    if (file_exists($pageFile)) {
        include $pageFile;
    }
    ?>

    <?php include __DIR__ . "/components/footer.php"; ?>
</body>
</html>
