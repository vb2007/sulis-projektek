<?php

namespace Acme\Frosty;

use Stringable;

class IceCream implements Stringable {
    private int $scoop;
    private int $price;
    private bool $sweetCone;
    private array $flavours = [];
    private static array $availableFlavours = ["vanilla", "strawberry", "chocolate", "coconut"];

    public function __construct(int $scoop, bool $sweetCone) {
        $this->scoop = $scoop;
        $this->sweetCone = $sweetCone;
        $this->price = $scoop * 400 + ($sweetCone ? 80 : 0);
    }

    public function __get(string $name) :mixed {
        return $this->$name ?? null;
    }

    public function __set(string $name, mixed $value) :void {
        if (property_exists($this, $name)) {
            $this->$name = $value;
        }
    }

    public static function availableFlavours() :array {
        return self::$availableFlavours;
    }

    public static function addFlavour(string $flavour) :void {
        self::$availableFlavours[] = $flavour; //vagy array_push(..., ...)
    }

    public function __tostring() :string {
        $flavoursUpper = array_map("strtoupper", $this->flavours);
        $flavoursStr = implode(", ", $flavoursUpper);

        $coneType = $this->sweetCone ? "édes tölcsérben" : "normál tölcsérben";

        return "{$this->scoop} gombócos fagylalt [{$flavoursStr}] ízekkel {$coneType} ({$this->price} Ft)";
    }

    public function toArray() :array {

    }
}
