<?php

namespace Foo;

class Tablet {
    private int $id;
    private int $manufacturer_id;
    private string $fullname;
    private float $screen;
    private int $storage;
    private string $os;
    private int $price;
    private static array $manufacturers = [ 1 => "Apple", 2 => "Samsung", 3 => "Huawei" ];

    public function __construct(int $id, int $manufacturer_id, string $fullname, float $screen, int $storage, string $os, int $price) {
        $this->id = $id;
        $this->manufacturer_id = $manufacturer_id;
        $this->fullname = $fullname;
        $this->screen = $screen;
        $this->storage = $storage;
        $this->os = $os;
        $this->price = $price;
    }

    public function __get(string $name): mixed {
        if ($name == "manufacturer") {
            return self::$manufacturers[$this->manufacturer_id];
        }

        if (property_exists($this, $name)) {
            return $this->$name;
        }

        return null;
    }

    public static function getManufacturers(): array {
        return self::$manufacturers;
    }

    public function getImagePath(): string {
        return "img/" . $this->id . ".webp";
    }
}
