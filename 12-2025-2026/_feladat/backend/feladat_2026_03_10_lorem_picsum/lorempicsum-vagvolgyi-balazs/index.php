<?php

error_reporting(E_ALL);

require __DIR__ . "/vendor/autoload.php";
require __DIR__ . "/data.php";

$whoops = new \Whoops\Run();
$whoops->pushHandler(new \Whoops\Handler\PrettyPageHandler());
$whoops->register();

$id =
    isset($_GET["id"]) && is_numeric($_GET["id"]) && $_GET["id"] >= 1
        ? (int) $_GET["id"]
        : 678;
$width =
    isset($_GET["width"]) && is_numeric($_GET["width"]) && $_GET["width"] >= 100
        ? (int) $_GET["width"]
        : 400;
$height =
    isset($_GET["height"]) &&
    is_numeric($_GET["height"]) &&
    $_GET["height"] >= 100
        ? (int) $_GET["height"]
        : 320;
$blur =
    isset($_GET["blur"]) &&
    is_numeric($_GET["blur"]) &&
    $_GET["blur"] >= 0 &&
    $_GET["blur"] <= 3
        ? (int) $_GET["blur"]
        : 0;
$grayscale = isset($_GET["grayscale"]);

$imageUrl = "https://picsum.photos/id/{$id}/{$width}/{$height}";

$queryParams = [];
if ($blur > 0) {
    $queryParams[] = "blur={$blur}";
}
if ($grayscale) {
    $queryParams[] = "grayscale";
}

if (!empty($queryParams)) {
    $imageUrl .= "?" . implode("&", $queryParams);
}

$menuColor = $colors[$id] ?? "#6b6b40";
?>
<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Lorem Picsum képválasztó</title>
    <link rel="stylesheet" href="style.css">
    <style>
        .navbar {
            background-color: <?= htmlspecialchars($menuColor) ?>;
        }
        h1 {
            color: <?= htmlspecialchars($menuColor) ?>;
        }
    </style>
</head>
<body>
    <?php include __DIR__ . "/components/menu.php"; ?>

    <main>
        <h1>Lorem Picsum képválasztó</h1>

        <div>
            <?php include __DIR__ . "/components/form.php"; ?>

            <aside>
                <img src="<?= htmlspecialchars(
                    $imageUrl,
                ) ?>" alt="Lorem Picsum">
            </aside>
        </div>
    </main>
</body>
</html>
