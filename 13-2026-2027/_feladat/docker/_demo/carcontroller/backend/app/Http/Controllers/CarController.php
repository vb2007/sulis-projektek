<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class CarController extends Controller
{
    public function index() {
        return ["data" => $this->loadCars()];
    }

    public function show(int $id) {
        $cars = $this->loadCars();
        return ["data" => $cars->firstWhere("id", "=", $id)]; //aka. ->where()->first()
    }

    private function loadCars()
    {
        return collect([
            [
                "id" => 1,
                "manufacturer" => "Audi",
                "model" => "A6",
                "color" => "szürke",
                "consumption" => 10.2,
                "background" => "gray",
                "image" => "audi-min.jpg",
                "url" => route("cars.show", ["id" => 1], false),
            ],
            [
                "id" => 2,
                "manufacturer" => "Suzuki",
                "model" => "Swift",
                "color" => "piros",
                "consumption" => 6.9,
                "background" => "red",
                "image" => "swift-min.jpg",
                "url" => route("cars.show", ["id" => 2], false),
            ],
            [
                "id" => 3,
                "manufacturer" => "Suzuki",
                "model" => "Ignis",
                "color" => "sárga",
                "consumption" => 7.3,
                "background" => "yellow",
                "image" => "ignis-min.jpg",
                "url" => route("cars.show", ["id" => 3], false),
            ]
        ]);
    }
}
