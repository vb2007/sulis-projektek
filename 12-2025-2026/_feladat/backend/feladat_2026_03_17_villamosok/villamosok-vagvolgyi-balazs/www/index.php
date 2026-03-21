<?php

error_reporting(E_ALL);

require __DIR__ . "/vendor/autoload.php";
require __DIR__ . "/data.php";

$whoops = new \Whoops\Run();
$whoops->pushHandler(new \Whoops\Handler\PrettyPageHandler());
$whoops->register();
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
