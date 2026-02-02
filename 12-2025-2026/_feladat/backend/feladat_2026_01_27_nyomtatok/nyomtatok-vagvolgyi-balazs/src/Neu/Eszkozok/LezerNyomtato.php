<?php

namespace Neu\Eszkozok;

use LogicException;

class LezerNyomtato extends Nyomtato {
    protected int $tonerekSzama;

    public function __construct(string $gyarto, string $tipus, bool $szines, int $ar, int $tonerekSzama) {
        parent::__construct($gyarto, $tipus, $szines, $ar);
        $this->tonerekSzama = $tonerekSzama;
    }

    public function __get($name): mixed {
        if (in_array($name, array_keys(get_object_vars($this)))) {
            return $this->$name;
        }

        throw new LogicException("Nem olvasható tulajdonság: $name");
    }

    public function __tostring(): string {
        return $this->gyarto . " " . $this->tipus . " " . ($this->szines ? "színes" : "fekete-fehér") . " lézernyomtató (" . $this->tonerekSzama . " toner) ". $this->ar . " Ft";
    }
}
