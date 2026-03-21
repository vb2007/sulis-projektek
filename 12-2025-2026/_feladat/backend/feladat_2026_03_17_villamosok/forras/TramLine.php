<?php

namespace Budapest\Transport;

class TramLine{
    private string $number;
    private string $route;
    private int $since;
    private string $interconnected;
    private float $length;
    private static $interconnecteds = ["none" => "Nincs", "budai" => "Budai Fonódó", "pesti" => "Pesti Fonódó"];

    public function __construct(string $number, string $route, int $since, string $interconnected, float $length){
        $this->number = $number;
        $this->route = $route;
        $this->since = $since;
        $this->interconnected = $interconnected;
        $this->length = $length;
    }

    public function __get($property){
        return $this->$property;
    }

    public function __set($property, $value){
        $this->$property = $value;
    }

    public function getInterconnected(){
        return TramLine::$interconnecteds[$this->interconnected];
    }

    public function getImagePath(){
        return "./img/" . strtolower($this->number) . ".jpg";
    }

    public static function getInterconnecteds(){
        return TramLine::$interconnecteds;
    }
}

?>