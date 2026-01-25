<?php

namespace Acme\Kozlekedes;

use LogicException;

class Roller extends Gepjarmu {
    protected int $kerekekSzama;

    protected function __construct(string $gyarto, string $tipus, string $szin, string $motor, int $kerekekSzama) {
        parent::__construct($gyarto, $tipus, $szin, $motor);
        $this->kerekekSzama = $kerekekSzama;
    }

    public function __get($name): void {
        if (in_array($name, array_keys(get_object_vars($this)))) {
            return $this->$name;
        }

        throw new LogicException("Nem olvasható tulajdonság: $name");
    }

    public function __tostring(): string {
        return "";
    }
}
