<?php

namespace Universe\Entities;

class Superhero {
    private string $name;
    private int $age;
    private array $superpowers;

    public function __construct(string $name, int $age, array $superpowers) {
        $this->name = $name;
        $this->age = $age;
        $this->superpowers = $superpowers;
    }

    public function getName(): string {
        return $this->name;
    }

    public function setName(string $name): void {
        $this->name = $name;
    }

    public function getAge(): int {
        return $this->age;
    }

    public function setAge(int $age): void {
        $this->age = $age;
    }

    public function getSuperpowers() : array {
        return $this->superpowers;
    }

    public function setSuperpowers(array $superpowers): void {
        $this->superpowers = $superpowers;
    }
}
