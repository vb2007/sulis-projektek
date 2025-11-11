<?php

require "adatok.php";

function vb() {
    $vbCount = 0;
    foreach ($versenyzok as $team => $drivers) {
        foreach ($drivers as $driver) {
            $total_vb += $driver["vb"];
        }
    }
}

function dobogo($rajtszam) {

}
