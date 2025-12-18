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
            return self::$osztalyzatok[$this->jegy - 1];
        }

        return $this->$name;
    }

    public function __set($name, $value) :void {
        $this->$name = $value;
    }

    public function __toString(): string {
        $osztalyzat = strtoupper(self::$osztalyzatok[$this->jegy - 1]);
        $datum = $this->beirva->format('Y.m.d H:i');

        return "{$this->jegy} - {$osztalyzat} ({$this->tantargy}) {$this->tanar} {$datum}";
    }

    public function toArray(bool $asszociativ = false): array {
        if ($asszociativ) {
            return [
                'tipus' => $this->tipus,
                'jegy' => $this->jegy,
                'osztalyzat' => self::$osztalyzatok[$this->jegy - 1],
                'tantargy' => $this->tantargy,
                'tanar' => $this->tanar,
                'beirva' => $this->beirva
            ];
        }

        return [
            $this->tipus,
            $this->jegy,
            self::$osztalyzatok[$this->jegy - 1],
            $this->tantargy,
            $this->tanar,
            $this->beirva
        ];
    }
}
