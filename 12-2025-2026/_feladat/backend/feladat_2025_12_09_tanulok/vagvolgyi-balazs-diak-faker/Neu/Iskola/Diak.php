<?php

namespace Neu\Iskola;

use DateTime;

class Diak {
    private string $vnev;
    private string $knev;
    private string $email;
    private DateTime $szuletett;
    private int $szamlalo;
    private int $sorszam;

    public function __construct(string $vnev, string $knev, string $email, DateTime $szuletett) {
        $this->vnev = $vnev;
        $this->knev = $knev;
        $this->email = $email;
        $this->szuletett = $szuletett;
        $this->szamlalo = 0;
        $this->sorszam = 0;
    }

    public function __get($name) {
        switch ($name) {
            case "teljes_nev":
                return $this->vnev . " " . $this->knev;
            case "szuletett_iso":
                return $this->szuletett;
            default:
                return $this->$name;
        }
    }

    public function __set($name, $value){
        $this->$name = $value;
    }
}
