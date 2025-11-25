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

    }

    public function setSpecies(string $species): void {

    }

    public function getPlanet(): string {

    }

    public function setPlanet(string $planet): void {

    }

    public function isFriendly(): bool {

    }

    public function setFriendly(bool $isFriendly): void {

    }
}
