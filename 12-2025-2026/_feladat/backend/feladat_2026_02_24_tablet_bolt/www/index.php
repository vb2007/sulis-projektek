<?php

declare(strict_types=1);
error_reporting(E_ALL);

require __DIR__ . "/vendor/autoload.php";

$whoops = new \Whoops\Run;
$whoops->pushHandler(new \Whoops\Handler\PrettyPageHandler);
$whoops->register();

$page = "home";

if (!empty($_GET["page"])) {
    $page = $_GET["page"];
}

if ($page != "table" && $page != "grid") {
    $page = "404";
}
