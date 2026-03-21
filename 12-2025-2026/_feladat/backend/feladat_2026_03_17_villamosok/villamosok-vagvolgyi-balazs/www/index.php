<?php

error_reporting(E_ALL);

require __DIR__ . "/vendor/autoload.php";
require __DIR__ . "/data.php";

// use Budapest\Transport\TramLine;

$whoops = new \Whoops\Run();
$whoops->pushHandler(new \Whoops\Handler\PrettyPageHandler());
$whoops->register();

$page = $_GET["page"] ?? "grid";
if ($page !== "table" && $page !== "grid") {
    $page = "grid";
}

$filteredLines = $lines;

if (!empty($_GET["terminus"])) {
    $terminus = $_GET["terminus"];
    $filteredLines = array_filter($filteredLines, function ($line) use (
        $terminus,
    ) {
        return stripos($line->route, $terminus) !== false;
    });
}

if (!empty($_GET["interconnected"])) {
    $interconnected = $_GET["interconnected"];
    $filteredLines = array_filter($filteredLines, function ($line) use (
        $interconnected,
    ) {
        return $line->interconnected === $interconnected;
    });
}
if (!empty($_GET["since"])) {
    $since = (int) $_GET["since"];
    $filteredLines = array_filter($filteredLines, function ($line) use (
        $since,
    ) {
        return $line->since <= $since;
    });

    usort($filteredLines, function ($a, $b) {
        return $a->since <=> $b->since;
    });
}

$lines = array_values($filteredLines);
?>

<!DOCTYPE html>
<html lang="hu">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Viszonylatok</title>
    <script src="https://cdn.jsdelivr.net/npm/@tailwindcss/browser@4"></script>
    <link rel="stylesheet" href="style.css">
</head>

<body class="p-2">
    <!-- menü -->
    <?php include __DIR__ . "/components/menu.php"; ?>
    <main class="w-11/12 mx-auto max-w-325 p-2">
        <!-- oldalak tartalma -->
        <?php include __DIR__ . "/pages/" . $page . ".php"; ?>
    </main>
</body>

</html>
