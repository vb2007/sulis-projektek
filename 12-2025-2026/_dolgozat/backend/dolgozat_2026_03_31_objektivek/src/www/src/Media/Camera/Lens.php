<?php

namespace Media\Camera;

class Lens
{
    private int $id;
    private string $name;
    private string $mount;
    private int $minFocalLength;
    private int $maxFocalLength;
    private float $minAperture;
    private float $maxAperture;
    private string $type;

    public static array $availableTypes = ["prime" => "Fix", "zoom" => "Zoom"];

    public function __construct(
        int $id,
        string $name,
        string $mount,
        int $minFocalLength,
        int $maxFocalLength,
        float $minAperture,
        float $maxAperture,
        string $type,
    ) {
        $this->id = $id;
        $this->name = $name;
        $this->mount = $mount;
        $this->minFocalLength = $minFocalLength;
        $this->maxFocalLength = $maxFocalLength;
        $this->minAperture = $minAperture;
        $this->maxAperture = $maxAperture;
        $this->type = $type;
    }

    public function __get(string $property): mixed
    {
        if (property_exists($this, $property)) {
            return $this->$property;
        }

        if ($property === "image" || $property === "img") {
            return "images/{$this->id}.webp";
        }

        throw new \InvalidArgumentException(
            "Property '{$property}' does not exist.",
        );
    }

    public function __set(string $property, mixed $value): void
    {
        if (!property_exists($this, $property)) {
            throw new \InvalidArgumentException(
                "Property '{$property}' does not exist.",
            );
        }

        $this->$property = $value;
    }

    public static function getAvailableTypes(): array
    {
        return self::$availableTypes;
    }
}
