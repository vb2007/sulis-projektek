<?php

namespace Acme\Vehicles;

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
      $this->$name = $value;
   }

   public function __tostring(): string {
      return $this->type . "\t" . $this->number . "\t" . $this->operator;
   }
}
