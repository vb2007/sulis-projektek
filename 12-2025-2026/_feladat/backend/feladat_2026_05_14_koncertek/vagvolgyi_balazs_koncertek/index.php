<?php
require __DIR__ . '/vendor/autoload.php';
use Event\Party\Concert;

$whoops = new \Whoops\Run;
$whoops->pushHandler(new \Whoops\Handler\PrettyPageHandler);
$whoops->register();
ob_start();

$title = 'Koncertek';
$action = $_GET["action"] ?? null;
?>

<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title><?= $title ?></title>
    <script src="https://cdn.jsdelivr.net/npm/@tailwindcss/browser@4"></script>
</head>
<body>
    <?php
        require 'components/header.php';
        require 'components/menu.php';
    ?>
    
    <main class="w-11/12 max-w-340 mx-auto my-4 overflow-scroll">
        <?php
        switch ($action) {
            case "index":
                $title = "Koncertek";
                $layout = $_GET["layout"] ?? null;
                switch ($layout) {
                    case "grid":
                        include __DIR__ . "/pages/grid.php";
                        break;
                        
                    case "table":
                        include __DIR__ . "/pages/table.php";
                        break;

                    default:
                        include __DIR__ . "/pages/grid.php";
                        break;
                }
                break;

            case "show":
                $title = "--koncert neve--";
                $id = $_GET["id"] ?? null;
                include __DIR__ . "/pages/show.php";
                break;

            case "create":
                $title = "Koncert rögzítése";
                include __DIR__ . "/pages/create.php";
                break;

            case "store":
                include __DIR__ . "/pages/table.php";
                break;

            case "404":
                $title = "Koncertek";
                include __DIR__ . "/pages/404.php";
                break;

            default:
                include __DIR__ . "/pages/grid.php";
                break;
        }
        ?>
    </main>

</body>
</html>

<?php
ob_end_flush();