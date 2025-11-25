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
}
