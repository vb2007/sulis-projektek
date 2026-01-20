<?php

namespace Neu\Nyilvantartas;

use DateTime;

class Dolgozo extends Szemely {
    private float $fizetes;

    public function __construct(string $nev, DateTime $szuletett, float $fizetes) {
        $this->nev = $nev;
    }
}
