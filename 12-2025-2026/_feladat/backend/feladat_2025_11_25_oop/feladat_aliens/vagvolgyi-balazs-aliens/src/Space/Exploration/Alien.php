<?php

namespace Space\Exploration;

class Alien {
    private string $species;
    private string $planet;
    private bool $isFriendly;

    public function __construct(string $species, string $planet, bool $isFriendly) {
        $this->species = $species;
        $this->planet = $planet;
        $this->isFriendly = $isFriendly;
    }

    public function getSpecies(): string {
        return $this->species;
    }

    public function setSpecies(string $species): void {
        $this->species = $species;
    }

    public function getPlanet(): string {
        return $this->planet;
    }

    public function setPlanet(string $planet): void {
        $this->planet = $planet;
    }

    public function isFriendly(): bool {
        return $this->isFriendly;
    }

    public function setFriendly(bool $isFriendly): void {
        $this->isFriendly = $isFriendly;
    }
}
