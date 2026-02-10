<?php
declare(strict_types=1);
error_reporting(E_ALL);

require __DIR__ . "/vendor/autoload.php";

$whoops = new \Whoops\Run;
$whoops->pushHandler(new \Whoops\Handler\PrettyPageHandler);
$whoops->register();

$title = "Videójátékok";
$backgroundColor = "lightcoral";

ob_start();
?>

<!doctype html>
<html lang="hu">
    <head>
        <meta charset="UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <title><?= $title ?></title>
        <script src="https://cdn.jsdelivr.net/npm/@tailwindcss/browser@4"></script>
        <style>
            body {
                background-color: <?= $backgroundColor ?>;
            }
        </style>
    </head>
    <body>
        <?php require __DIR__ . "/pages/games.php"; ?>
    </body>
</html>

<?php
ob_end_flush();
?>
