<?php

namespace Neu\Eszkozok;

use LogicException;

class Nyomtato {
    protected string $gyarto;
    protected string $tipus;
    protected bool $szines;
    protected int $ar;
    private static array $gyartok = ["HP", "Canon", "Xerox", "Epson"];

    public function __construct(string $gyarto, string $tipus, bool $szines, int $ar) {
        $this->gyarto = $gyarto;
        $this->tipus = $tipus;
        $this->szines = $szines;
        $this->ar = $ar;
    }

    public function getGyartok(): array {
        return $this->gyartok;
    }

    public function __get($name): mixed {
        if (in_array($name, array_keys(get_object_vars($this)))) {
            return $this->$name;
        }

        throw new LogicException("Nem olvasható tulajdonság: $name");
    }
}
