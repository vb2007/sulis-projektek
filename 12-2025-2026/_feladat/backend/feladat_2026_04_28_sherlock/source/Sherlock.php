<?php

namespace Series\Bbc;

use Exception;

class Sherlock
{
    private int $id;
    private string $title;
    private int $length;
    private string $director;
    private string $writer;
    private string $published;
    private float $viewers;

    public function __construct(int $id, string $title, int $length, string $director, string $writer, string $published, float $viewers)
    {
        $this->id = $id;
        $this->title = $title;
        $this->length = $length;
        $this->director = $director;
        $this->writer = $writer;
        $this->published = $published;
        $this->viewers = $viewers;
    }

    public function __get($name):mixed{
        if(!property_exists($this,$name))
        {
            throw new Exception("Unknown property: '$name'");
        }
        return $this->$name;
    }
}
