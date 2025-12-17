<?php

namespace Acme\Iskola;

use DateTime;

class Jegy {
    private static array $tipusok = ["Témazáró", "Órai munka", "Teszt"];
    private static array $osztalyzatok = ["elégtelen", "elégséges", "közepes", "jó", "jeles"];
    private static array $tantargyak = ["Matematika", "Angol", "Programozás", "Nyelvtan", "Történelem"];
    private string $tipus;
    private int $jegy;
    private string $tantargy;
    private string $tanar;
    private DateTime $beirva;

    private function __construct(string $tipus, int $jegy, string $tantargy, string $tanar, DateTime $beirva) {
        $this->tipus = $tipus;
        $this->jegy = $jegy;
        $this->tantargy = $tantargy;
        $this->tanar = $tanar;
        $this->beirva = $beirva;
    }

    private function lehetsegesTipusok() :array {
        return $this->tipusok;
    }

    private function lehetsegesOsztalyzatok() :array {
        return $this->osztalyzatok;
    }

    private function lehetsegesTantargyak() :array {
        return $this->tantargyak;
    }
}
