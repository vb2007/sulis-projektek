<?php

namespace Neu\Nyilvantartas;

use DateTime;
use Stringable;

class Dolgozo extends Szemely implements Stringable {
    private float $fizetes;

    public function __construct(string $nev, DateTime $szuletett, float $fizetes) {
        // $this->nev = $nev;
        // $this->szuletett = $szuletett;
        parent::__construct($nev, $szuletett); //MINDIG ezzel kell kezdeni
        $this->fizetes = $fizetes;
    }

    public function __tostring(): string {
        return parent::__toString() . " Fizetés: " . number_format($this->fizetes, 0, ",", " ") . " Ft";
    }
}
