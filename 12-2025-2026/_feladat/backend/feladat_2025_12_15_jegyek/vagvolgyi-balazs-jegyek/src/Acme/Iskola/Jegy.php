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

    public function __construct(string $tipus, int $jegy, string $tantargy, string $tanar, DateTime $beirva) {
        $this->tipus = $tipus;
        $this->jegy = $jegy;
        $this->tantargy = $tantargy;
        $this->tanar = $tanar;
        $this->beirva = $beirva;
    }

    public static function lehetsegesTipusok(): array {
        return self::$tipusok;
    }

    public static function lehetsegesOsztalyzatok(): array {
        return self::$osztalyzatok;
    }

    public static function lehetsegesTantargyak(): array {
        return self::$tantargyak;
    }

    public function __get($name) :mixed {
        if ($name == "osztalyzat") {
            return $this->osztalyzatok[$this->jegy];
        }

        return $this->$name;
    }

    public function __set($name, $value) :void {
        $this->$name = $value;
    }

    public function __tostring() :string {
        return "";
    }

    public function toArray(bool $asszociativ) :array {

    }
}
