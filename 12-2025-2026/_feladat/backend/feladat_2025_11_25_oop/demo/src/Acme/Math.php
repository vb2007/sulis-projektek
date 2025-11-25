<?php

namespace Acme;

class Math {
    private int $a;
    private int $b;

    public function __construct(int $a, int $b) {
        $this->a = $a;
        $this->b = $b;
    }

    public function sum(): int {
        return $this->a + $this->b;
    }

    public function sub(): int {
        return $this->a - $this->b;
    }
}
