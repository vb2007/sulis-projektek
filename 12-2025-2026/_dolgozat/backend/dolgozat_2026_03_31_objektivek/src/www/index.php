<?php
require __DIR__ . "/vendor/autoload.php";

$whoops = new \Whoops\Run();
$whoops->pushHandler(new \Whoops\Handler\PrettyPageHandler());
$whoops->register();

require "data.php";

$mount = $_GET["mount"] ?? "";
$type = $_GET["type"] ?? "";
$minFocalLength = $_GET["minFocalLength"] ?? "";

if (!empty($mount)) {
    $lenses = array_filter(
        $lenses,
        fn($lens) => stripos($lens->mount, $mount) !== false,
    );
}

if (!empty($type)) {
    $lenses = array_filter(
        $lenses,
        fn($lens) => $lens->type === $type &&
            stripos($lens->mount, "Canon") !== false,
    );
}

if (!empty($minFocalLength)) {
    $lenses = array_filter(
        $lenses,
        fn($lens) => $lens->maxFocalLength <= 100 &&
            $lens->minFocalLength >= $minFocalLength,
    );
}

usort(
    $lenses,
    fn($a, $b) => $a->minFocalLength !== $b->minFocalLength
        ? $a->minFocalLength <=> $b->minFocalLength
        : $b->minAperture <=> $a->minAperture,
);

$page = "grid";
if (!empty($_GET["page"])) {
    $page = $_GET["page"];
}

if ($page !== "grid" && $page !== "table") {
    $page = "grid";
}

$title = "Objektívek";
ob_start();
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title><?= $title ?></title>
    <script src="https://cdn.jsdelivr.net/npm/@tailwindcss/browser@4"></script>
    <link rel="stylesheet" href="style.css">
</head>
<body class="bg-zinc-100 mb-4">
    <?php include __DIR__ . "/components/menu.php"; ?>

    <?php
    $pageFile = __DIR__ . "/pages/" . $page . ".php";
    if (file_exists($pageFile)) {
        include $pageFile;
    }
    ?>
</body>
</html>
<?php ob_end_flush();
?>
