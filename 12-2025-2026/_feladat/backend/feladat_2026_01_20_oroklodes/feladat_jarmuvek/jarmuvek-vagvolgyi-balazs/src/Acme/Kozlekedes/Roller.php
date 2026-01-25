<?php

namespace Acme\Kozlekedes;

use LogicException;

class Roller extends Jarmu {
    protected int $kerekekSzama;

    public function __construct(string $gyarto, string $tipus, string $szin, int $kerekekSzama) {
        parent::__construct($gyarto, $tipus, $szin);
        $this->kerekekSzama = $kerekekSzama;
    }

    public function __get(string $name): mixed {
        if (in_array($name, array_keys(get_object_vars($this)))) {
            return $this->$name;
        }

        throw new LogicException("Nem olvasható tulajdonság: $name");
    }

    public function __tostring(): string {
        return sprintf('"%s","%s","%s",%d', $this->gyarto, $this->tipus, $this->szin, $this->kerekekSzama);
    }
}
