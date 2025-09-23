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

switch ($unit) {
    case "c":
    case "celsius":
        $convertedTemp = $temp * 1.8 + 32;
        echo "{$temp} celsius az {$convertedTemp} fahrenheit\n";
        break;
    case "f":
    case "fahrenheit":
        $convertedTemp = ($temp - 32) / 1.8;
        echo "{$temp} fahrenheit az {$convertedTemp} celsius\n";
        break;
    default:
        echo "Hibás mértékegység\n";
        return;
}
