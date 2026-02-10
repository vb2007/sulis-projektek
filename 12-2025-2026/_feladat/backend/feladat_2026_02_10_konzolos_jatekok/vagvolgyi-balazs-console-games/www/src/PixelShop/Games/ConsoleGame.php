<?php

declare(strict_types=1);

namespace PixelShop\Games;

use InvalidArgumentException;

class ConsoleGame {
    private int $id;
    private string $platform;
    private string $title;
    private int $price;
    private string $imageName;

    public function __construct(int $id, string $platform, string $title, int $price, string $imageName) {
        $this->id = $id;
        $this->platform = $platform;
        $this->title = $title;
        $this->price = $price;
        $this->imageName = $imageName;
    }

    public function __get($property):mixed {
        if ("platformClass" == $property) {
            if ("PS5" == $this->platform) {
                return "bg-blue-100 text-blue-700";
            } else if ("Nintendo Switch" == $this->platform) {
                return "bg-red-100 text-red-700";
            } else if ("XBOX Series X" == $this->platform) {
                return "bg-green-100 text-green-700";
            } else {
                return "bg-gray-100 text-gray-700";
            }
        }
        if (!property_exists($this, $property)) {
            throw new InvalidArgumentException("Property '{$property}' does not exist.");
        }
        return $this->$property;
    }

    public function __set($property, $value): void
    {
        if (!property_exists($this, $property)) {
            throw new InvalidArgumentException("Property '{$property}' does not exist.");
        }
        $this->$property = $value;
    }
}
