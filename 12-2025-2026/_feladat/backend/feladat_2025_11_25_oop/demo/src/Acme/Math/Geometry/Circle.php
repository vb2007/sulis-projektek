<?php

namespace Acme\Math\Geometry;

class Circle {
    private float $r;

    public function __construct(float $r) {
        $this->r = $r;
    }

    public function circumference(): float {
        return $this->r * 2 * pi();
    }

    public function area(): float {
        return $this->r * $this->r * pi();
    }
}
