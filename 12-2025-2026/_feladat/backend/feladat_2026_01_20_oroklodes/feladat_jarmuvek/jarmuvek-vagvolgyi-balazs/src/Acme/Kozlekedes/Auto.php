<?php

namespace Acme\Kozlekedes;

use LogicException;

class Auto extends Gepjarmu {
    protected int $ajtok;

    public function __construct(string $gyarto, string $tipus, string $szin, string $motor, int $ajtok) {
        parent::__construct($gyarto, $tipus, $szin, $motor);
        $this->ajtok = $ajtok;
    }

    public function __get(string $name): mixed {
        if (in_array($name, array_keys(get_object_vars($this)))) {
            return $this->$name;
        }

        throw new LogicException("Nem olvasható tulajdonság: $name");
    }

    public function __tostring(): string {
        return sprintf('"%s","%s","%s",%d', $this->gyarto, $this->tipus, $this->szin, $this->ajtok);
    }
}
