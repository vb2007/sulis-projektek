<?php

namespace Acme\Graphics\Shapes;

class Circle {
    private int $x;
    private int $y;
    private int $size;

    public function __construct(int $x, int $y, int $size) {
        $this->x = $x;
        $this->y = $y;
        $this->size = $size;
    }

    public function position(): array {
        return [$this->x, $this->y];
    }

    public function getSize(): int {
        return $this->size;
    }

    public function setSize(int $size) {
        if ($size < 0) {
            $this->size = 0;
        }
        else {
            $this->size = $size;
        }
    }
}
