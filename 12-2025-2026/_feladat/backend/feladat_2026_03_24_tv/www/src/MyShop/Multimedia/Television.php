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

    private static $manufacturers = [
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
    ) {}
}
