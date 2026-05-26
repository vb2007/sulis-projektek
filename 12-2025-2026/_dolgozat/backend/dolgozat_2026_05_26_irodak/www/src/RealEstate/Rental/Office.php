<?php

namespace RealEstate\Rental;

use Exception;

class Office {
    private int $id;
    private string $name;
    private string $address;
    private int $price;
    private float $rooms;

    public function __construct(int $id, string $name, string $address, int $price, float $rooms)
    {
        $this->id = $id;
        $this->name = $name;
        $this->address = $address;
        $this->price = $price;
        $this->rooms = $rooms;
    }

    public function __get(string $property): mixed {
        if ($property == "image") {
            return $_SERVER['DOCUMENT_ROOT'] . "/images/" . $this->id . ".png";
        }

        if (property_exists($this, $property)) {
            return $this->$property;
        }
        throw new Exception("Property $property does not exists");
    }

    public function __set(string $property, mixed $value): void {
        if (property_exists($this, $property)) {
            $this->$property = $value;
        }
    }
}