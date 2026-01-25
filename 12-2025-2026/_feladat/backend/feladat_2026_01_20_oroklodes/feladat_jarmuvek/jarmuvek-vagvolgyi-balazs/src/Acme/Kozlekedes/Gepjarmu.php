<?php

namespace Acme\Kozlekedes;

use LogicException;

class Gepjarmu extends Jarmu {
    protected string $motor;

    protected function __construct(string $gyarto, string $tipus, string $szin, string $motor) {
        parent::__construct($gyarto, $tipus, $szin);
        $this->motor = $motor;
    }

    public function __get($name): void {
        if (in_array($name, array_keys(get_object_vars($this)))) {
            return $this->$name;
        }

        throw new LogicException("Nem olvasható tulajdonság: $name");
    }
}
