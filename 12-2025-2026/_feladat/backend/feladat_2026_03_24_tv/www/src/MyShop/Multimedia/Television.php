<?php

namespace MyShop\Multimedia;

class Television
{
    private int $id;
    private string $name;
    private int $manufacturer_id;
    private int $size;
    private string $resolution;
    private string $technology;
    private bool $hdr;
    private int $price;

    private static array $manufacturers = [
        1 => "Samsung",
        2 => "LG",
        3 => "Philips",
    ];

    public function __construct(
        int $id,
        string $name,
        int $manufacturer_id,
        int $size,
        string $resolution,
        string $technology,
        bool $hdr,
        int $price,
    ) {
        $this->id = $id;
        $this->name = $name;
        $this->manufacturer_id = $manufacturer_id;
        $this->size = $size;
        $this->resolution = $resolution;
        $this->technology = $technology;
        $this->hdr = $hdr;
        $this->price = $price;
    }
}
