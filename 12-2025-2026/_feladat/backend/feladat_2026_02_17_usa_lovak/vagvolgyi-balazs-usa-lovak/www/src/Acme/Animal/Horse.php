<?php

namespace Acme\Animal;

class Horse {
    private int $id;                // azonosító
    private string $state;          // állam
    private string $breed;          // fajta
    private string $description;    // leírás
    private string $image;          // kép
    private int $year;              // év

    private static array $states = [
        "AL"=>"Alabama",
        "AK"=>"Alaska",
        "AZ"=>"Arizona",
        "AR"=>"Arkansas",
        "CA"=>"California",
        "CO"=>"Colorado",
        "CT"=>"Connecticut",
        "DE"=>"Delaware",
        "FL"=>"Florida",
        "GA"=>"Georgia",
        "HI"=>"Hawaii",
        "ID"=>"Idaho",
        "IL"=>"Illinois",
        "IN"=>"Indiana",
        "IA"=>"Iowa",
        "KS"=>"Kansas",
        "KY"=>"Kentucky",
        "LA"=>"Louisiana",
        "ME"=>"Maine",
        "MD"=>"Maryland",
        "MA"=>"Massachusetts",
        "MI"=>"Michigan",
        "MN"=>"Minnesota",
        "MS"=>"Mississippi",
        "MO"=>"Missouri",
        "MT"=>"Montana",
        "NE"=>"Nebraska",
        "NV"=>"Nevada",
        "NH"=>"New Hampshire",
        "NJ"=>"New Jersey",
        "NM"=>"New Mexico",
        "NY"=>"New York",
        "NC"=>"North Carolina",
        "ND"=>"North Dakota",
        "OH"=>"Ohio",
        "OK"=>"Oklahoma",
        "OR"=>"Oregon",
        "PA"=>"Pennsylvania",
        "RI"=>"Rhode Island",
        "SC"=>"South Carolina",
        "SD"=>"South Dakota",
        "TN"=>"Tennessee",
        "TX"=>"Texas",
        "UT"=>"Utah",
        "VT"=>"Vermont",
        "VA"=>"Virginia",
        "WA"=>"Washington",
        "WV"=>"West Virginia",
        "WI"=>"Wisconsin",
        "WY"=>"Wyoming",
    ];

    public function __construct($id, $state, $breed, $description, $image, $year)
    {
        $this->id = $id;
        $this->state = $state;
        $this->breed = $breed;
        $this->description = $description;
        $this->image = $image;
        $this->year = $year;
    }

    public function __get(string $name) :mixed
    {
        if ($name == "path") {
            return "img/" . $this->image;
        }

        if(property_exists($this,$name))
        {
            return $this->$name;
        }
        return null;
    }

    public function __set(string $name, mixed $value):void
    {
        if(property_exists($this,$name))
        {
            $this->$name = $value;
        }
    }

    public static function getStates():array
    {
        return self::$states;
    }
}
