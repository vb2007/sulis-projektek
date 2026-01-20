<?php

namespace Acme\Kozlekedes;

class Gepjarmu extends Jarmu {
    protected string $motor;

    protected function __construct(string $gyarto, string $tipus, string $szin, $motor) {
        parent::__construct($gyarto, $tipus, $szin);
        $this->motor = $motor;
    }
}
