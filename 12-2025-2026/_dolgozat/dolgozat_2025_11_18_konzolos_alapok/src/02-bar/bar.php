<?php

require "data.php";

function average() {
    global $customers;

    $customerCount = 0;
    $totalSpent = 0;
    foreach($customers as $date => $people) {
        foreach ($people as $customer) {
            $customerCount++;
            $totalSpent += $customer["paid"];
        }
    }

    return $totalSpent / $customerCount;
}

function name($id) {
    global $customers;

    foreach($customers as $date => $people) {
        foreach ($people as $customer) {
            if ($id == $customer["id"]) {
                return $customer["name"];
            }
        }
    }

    return null;
}

if ($argc > 2) {
    echo "Túl sok paraméter!\n";
    exit(5);
}

if ($argc == 1) {
    foreach($customers as $date => $people) {
        foreach ($people as $customer) {
            $name = explode(" ", $customer["name"]);
            $firstName = mb_strtoupper($name[1]);

            echo $firstName . " #" . $customer["id"] . " (" . $customer["birth"] . ", " . $customer["region"] . ") [" . $date . "]\n";
        }
    }

    exit;
}

$param = $argv[1];
if ($param == "atlag") {
    echo average() . "\n";
}

if ($param >= 1 && $param <= 100) {
    $name = name($param);

    echo ($name != null ? $name : "Nincs ilyen azonosítójú vendég!") . "\n";
}
