<?php

use App\Http\Controllers\CarController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;


Route::get("cars",
    [CarController::class, "index"])
        ->name("cars.name");

Route::get("cars/{id}",
    [CarController::class, "show"])
        ->name("cars.show");