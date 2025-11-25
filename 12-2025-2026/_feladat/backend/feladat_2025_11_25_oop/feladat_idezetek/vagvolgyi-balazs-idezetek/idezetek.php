<?php

declare(strict_types=1);

require "src/Culture/Movie/Quotation.php";

use Culture\Movie\Quotation;

$quotations = [
    new Quotation("Az Erő legyen veled.", "Obi-Wan Kenobi", "Csillagok háborúja"),
    new Quotation("Az új magyar narancs. Kicsit sárgább, kicsit savanyúbb, de a mienk!", "Pelikán", "A tanú"),
    new Quotation("Tigris van a fürdőszobában!", "Stu Price", "Másnaposok")
];

foreach($quotations as $quotation) {
    echo $quotation->getText() . PHP_EOL . $quotation->getPerson() . " - " . $quotation->getTitle();
}
