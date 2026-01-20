<?php

namespace Neu\Nyilvantartas;

use DateTime;
use LogicException;
use Stringable;

class Szemely implements Stringable {
    protected string $nev;
    protected DateTime $szuletett;

    public function __construct(string $nev, DateTime $szuletett) {
        $this->nev = $nev;
        $this->szuletett = $szuletett;
    }

    public function __get(string $tulajdonsag): mixed {
        if (in_array($tulajdonsag, array_keys(get_object_vars($this)))) {
            return $this->$tulajdonsag;
        }

        throw new LogicException("Nem olvasható tulajdonság: $tulajdonsag");
    }

    public function __tostring(): string {
        return $this->nev . " " . $this->szuletett->format("Y-m-d");
    }
}
