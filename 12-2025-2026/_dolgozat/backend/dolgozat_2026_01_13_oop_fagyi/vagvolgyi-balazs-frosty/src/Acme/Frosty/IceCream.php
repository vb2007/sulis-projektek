<?php

namespace Acme\Frosty;

use Stringable;

class IceCream implements Stringable {
    private int $scoop;
    private int $price;
    private bool $sweetCone;
    private array $flavours;
    private static array $availableFlavours = ["vanilla", "strawberry", "chocolate", "coconut"];

    public function __construct(int $scoop, bool $sweetCone) {
        $this->scoop = $scoop;
        $this->sweetCone = $sweetCone;
        $sweetCone ? $this->price = $scoop * 480 : $this->price = $scoop * 400;
        // if ($sweetCone) {
        //     $this->price = $scoop * 480;
        // }
        // else {
        //     $this->price = $scoop * 400;
        // }
    }

    public function __get(string $name) :mixed {
        return $this->$name;
    }

    public function __set(string $name, mixed $value) :void {
        $this->$name = $value;
    }

    //static?
    public function availableFlavours() :array {
        return $this->availableFlavours;
    }

    public function addFlavour(string $flavour) :void {
        array_push($availableFlavours, $flavour);
    }

    public function __tostring() :string {
        return "";
    }

    public function toArray() :array {

    }
}
