<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

use App\Http\Controllers\HeroContentController;
use App\Http\Controllers\TeaserController;
use App\Http\Controllers\TimetableController;
use App\Http\Controllers\TrainController;

Route::get("hero-contents",
    [HeroContentController::class, "index"])
        ->name("hero-contents.index");

Route::get("teasers",
    [TeaserController::class, "index"])
        ->name("teasers.index");

Route::get("trains/{train}",
    [TrainController::class, "show"])
        ->name("trains.show");

Route::get("timetable/stations/origins",
    [TimetableController::class, "origins"])
        ->name("timetable.origins");

Route::get("timetable/stations/destinations",
    [TimetableController::class, "destinations"])
        ->name("timetable.destinations");