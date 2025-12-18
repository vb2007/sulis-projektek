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

    public function __tostring() :string {
        $capTitle = strtoupper($this->cim);
        $formattedPrice = number_format($this->ar, 0, '', ' ') . " Ft";
        $room = "[{$this->terem} terem {$this->sor} sor {$this->ules}. ülés]";
        $startTime = $this->kezdes->format('Y-m-d H:i');
        $ageRating = $this->felnott ? " (18+)" : "";

        return "{$capTitle} {$formattedPrice} {$room} {$startTime}{$ageRating}";
    }

    public function toArray(bool $asszociativ = false) :array {
        $formattedPrice = number_format($this->ar, 0, '', ' ') . " Ft";
        $korhataros = $this->felnott ? "igen" : "nem";

        if ($asszociativ) {
            return [
                "cim" => $this->cim,
                "ar" => $formattedPrice,
                "terem" => $this->terem,
                "sor" => $this->sor,
                "ules" => $this->ules,
                "kezdes" => $this->kezdes,
                "korhataros" => $korhataros
            ];
        }

        return [
            $this->cim,
            $formattedPrice,
            $this->terem,
            $this->sor,
            $this->ules,
            $this->kezdes,
            $korhataros
        ];
    }
}
