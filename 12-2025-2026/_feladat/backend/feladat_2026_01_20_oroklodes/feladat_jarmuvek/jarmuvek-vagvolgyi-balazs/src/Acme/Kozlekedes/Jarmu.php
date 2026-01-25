<?php

namespace Acme\Kozlekedes;

use LogicException;

class Jarmu {
    protected string $gyarto;
    protected string $tipus;
    protected string $szin;

    public function __construct(string $gyarto, string $tipus, string $szin) {
        $this->gyarto = $gyarto;
        $this->tipus = $tipus;
        $this->szin = $szin;
    }

    public function __get(string $name): mixed {
        if (in_array($name, array_keys(get_object_vars($this)))) {
            return $this->$name;
        }

        throw new LogicException("Nem olvasható tulajdonság: $name");
    }
}
