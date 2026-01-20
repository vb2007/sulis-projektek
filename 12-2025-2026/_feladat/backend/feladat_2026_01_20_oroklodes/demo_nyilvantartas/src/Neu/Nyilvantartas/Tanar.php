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
        $this->tantargyak = [];
    }

    public function addTantargy(string $tantargy): void {
        array_push($this->tantargyak, $tantargy);
    }

    public function __tostring(): string {
        return $this->om . " " . parent::__toString() . "(" . implode(", ", $this->tantargyak) . ")";
    }
}
