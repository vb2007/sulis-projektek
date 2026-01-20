<?php

namespace Neu\Nyilvantartas;

use DateTime;
use Stringable;

class Tanar extends Dolgozo implements Stringable {
    protected string $om;
    protected array $tantargyak;

    public function __construct(string $nev, DateTime $szuletett, float $fizetes, string $om) {
        parent::__construct($nev, $szuletett, $fizetes);
        $this->om = $om;
    }

    public function __tostring(): string {
        return parent::__toString() . " Fizetés: " . number_format($this->fizetes, 0, ",", " ") . " Ft";
    }
}
