<?php

error_reporting(E_ALL);

require __DIR__ . "/vendor/autoload.php";
require __DIR__ . "/data.php";

$whoops = new \Whoops\Run();
$whoops->pushHandler(new \Whoops\Handler\PrettyPageHandler());
$whoops->register();

$page = $_GET["page"] ?? "products";
if ($page !== "seller" && $page !== "products") {
    $page = "404";
}
?>

<!doctype html>
<html lang="hu">
    <head>
        <meta charset="UTF-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <title>TV 10 darab</title>
        <link rel="stylesheet" href="css/tv.css" />
        <script src="https://cdn.jsdelivr.net/npm/@tailwindcss/browser@4"></script>
    </head>

    <body>
    </body>

</html>
