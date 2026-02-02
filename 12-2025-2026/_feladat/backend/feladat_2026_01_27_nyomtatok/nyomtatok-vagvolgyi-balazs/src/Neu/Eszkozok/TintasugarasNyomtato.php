<?php

namespace Neu\Eszkozok;

use LogicException;

class TintasugarasNyomtato extends Nyomtato {
    protected int $patronokSzama;

    public function __construct(string $gyarto, string $tipus, bool $szines, int $ar, int $patronokSzama) {
        parent::__construct($gyarto, $tipus, $szines, $ar);
        $this->patronokSzama = $patronokSzama;
    }

    public function __get($name): mixed {
        if (in_array($name, array_keys(get_object_vars($this)))) {
            return $this->$name;
        }

        throw new LogicException("Nem olvasható tulajdonság: $name");
    }

    public function __toString(): string {
        return $this->gyarto . " " . $this->tipus . " " . ($this->szines ? "színes" : "fekete-fehér") . " tintasugaras nyomtató (" . $this->patronokSzama . " patron) ". $this->ar . " Ft";
    }

    public function toArray(): array {
        return [
            'gyarto' => $this->gyarto,
            'tipus' => $this->tipus,
            'szines' => $this->szines,
            'ar' => $this->ar,
            'patronokSzama' => $this->patronokSzama
        ];
    }
}
