<?php

namespace Acme\Mozi;

use DateTime;

class Jegy {
    private static array $termek = ["Spielberg", "Bujtor", "Coppola", "Hitchcock"];
    private string $cim;
    private int $ar;
    private string $terem;
    private string $sor;
    private int $ules;
    private DateTime $kezdes;
    private bool $felnott;

    public function __construct(string $cim, int $ar, string $terem, string $sor, int $ules, DateTime $kezdes, bool $felnott) {
        $this->cim = $cim;
        $this->ar = $ar;
        $this->terem = $terem;
        $this->sor = $sor;
        $this->ules = $ules;
        $this->kezdes = $kezdes;
        $this->felnott = $felnott;
    }

    public static function termekNevei() :array {
        return self::$termek;
    }

    public function __get($name) :mixed {
        return $this->$name;
    }

    public function __set($name, $value) :void {
        $this->$name = $value;
    }
}
