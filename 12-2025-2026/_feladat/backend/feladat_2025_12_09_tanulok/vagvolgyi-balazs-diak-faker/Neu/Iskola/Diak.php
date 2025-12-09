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

    public function __construct(string $vnev, string $knev, string $email, DateTime $szuletett, int $szamlalo, int $sorszam) {
        $this->vnev = $vnev;
        $this->knev = $knev;
        $this->email = $email;
        $this->szuletett = $szuletett;
        $this->szamlalo = $szamlalo;
        $this->sorszam = $sorszam;
    }
}
