<?php
require __DIR__ . '/vendor/autoload.php';

$whoops = new \Whoops\Run;
$whoops->pushHandler(new \Whoops\Handler\PrettyPageHandler);
$whoops->register();

$title = 'Koncertek';

ob_start();
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
        
    </main>

</body>
</html>
<?php
ob_end_flush();