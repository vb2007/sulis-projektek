<?php

namespace Event\Party;

use DateTime;
use Exception;
use Stringable;

class Concert implements Stringable {

    private int $id;
    private string $name;
    private string $location;
    private string $type;
    private DateTime $date;
    private int $price;
    private static array $types = [
        'rock' => 'Rock',
        'pop' => 'Pop',
        'electronic' => 'Elektronikus',
        'hiphop' => 'Hiphop',
        'other' => 'Egyéb'
    ];

    public function __construct(int $id, string $name, string $location, string $type, string $date, int $price)
    {
        $this->id = $id;
        $this->name = $name;
        $this->location = $location;
        $this->type = $type;
        $this->date = new DateTime($date);
        $this->price = $price;
    }

    public function __get(string $name) : mixed {
        return property_exists($this, $name) ? $this->$name : throw new Exception("Property $name does not exists");
    }

    public function __set(string $name, mixed $value) : void {
        property_exists($this, $name) ? $this->$name = $value : throw new Exception("Property $name does not exists");
    }
    
    public function __toString(): string
    {
        return "$this->id;$this->name;$this->location;$this->type;$this->date;$this->price";
    }

    public static function getTypes(): array {
        return self::$types;
    }
}