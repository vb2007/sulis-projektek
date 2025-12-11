<?php

namespace Acme\Vehicles;

use Exception;

class Train {
   private int $number;
   private string $type;
   private string $operator;

   public function __construct(int $number, string $type, string $operator) {
      $this->number = $number;
      $this->type = $type;
      $this->operator = $operator;
   }

   public function __get($name): void {
      return $this->$name;
   }

   public function __set($name, $value): void {
      if (in_array($name, ["type", "operator"])) {
         $this->$name = $value;
      }
      else if (property_exists($this, $name)) {
         throw new Exception("A $name tulajdonság privát.");
      }
      else {
         throw new Exception("Nem létezik $name tulajdonság");
      }
   }

   public function __tostring(): string {
      return $this->type . "\t" . $this->number . "\t" . $this->operator;
   }
}
