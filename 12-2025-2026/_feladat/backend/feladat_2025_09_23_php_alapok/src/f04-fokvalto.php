<?php

//paraméter nélkül is 1 az $argc értéke
if ($argc < 3) {
    echo "Túl kevés paraméter\n";
    return;
}

if ($argc > 3) {
    echo "Túl sok paraméter\n";
    return;
}

$temp = $argv[1];
$unit = strtolower($argv[2]);

if (!is_numeric($temp)) {
    echo "Hibás hőfok\n";
    return;
}

if ($unit != "c" && $unit != "f") {
    echo "Hibás mértékegység\n";
    return;
}
