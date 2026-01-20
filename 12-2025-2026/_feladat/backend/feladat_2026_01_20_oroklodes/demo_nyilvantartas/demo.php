<?php
declare(strict_types=1);

require __DIR__ . "/vendor/autoload.php";

use Neu\Nyilvantartas\Szemely;

$szemely = new Szemely("John Pork", DateTime::createFromFormat("Y-m-d", "2002-01-20"));
echo $szemely;
