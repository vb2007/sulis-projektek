<?php

namespace Acme\Kozlekedes;

use LogicException;

class Busz extends Gepjarmu {
    protected int $ulesek;

    protected function __construct(string $gyarto, string $tipus, string $szin, string $motor, int $ulesek) {
        parent::__construct($gyarto, $tipus, $szin, $motor);
        $this->ajtok = $ulesek;
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
