<?php

error_reporting(E_ALL);

require __DIR__ . "/vendor/autoload.php";
require __DIR__ . "/data/data.php";

$whoops = new \Whoops\Run();
$whoops->pushHandler(new \Whoops\Handler\PrettyPageHandler());
$whoops->register();

$action = "home";
if (!empty($_GET["action"])) {
    $action = $_GET["action"];
    if ($action != "create") {
        $action = "404";
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
