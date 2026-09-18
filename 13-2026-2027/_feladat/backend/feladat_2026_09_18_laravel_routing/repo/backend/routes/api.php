<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

use App\Http\Controllers\QuoteController;
use App\Http\Controllers\CalendarController;

//QuoteController

Route::get("idezetek/house",
    [QuoteController::class, "house"])
        ->name("quote.house");

Route::get("idezetek/modern-family",
    [QuoteController::class, "modernFamily"])
        ->name("quote.modernFamily");

Route::get("idezetek/uvegtigris/csoki",
    [QuoteController::class, "uvegtigrisCsoki"])
        ->name("quote.uvegtigrisCsoki");

Route::get("idezetek/uvegtigris/lali",
    [QuoteController::class, "uvegtigrisLali"])
        ->name("quote.uvegtigrisLali");

Route::get("idezetek/harry-potter/{slug}",
    [QuoteController::class, "harryPotter"])
        ->name("quote.harryPotter");

//CalendarController

Route::get("naptar/ma",
    [CalendarController::class, "today"])
        ->name("calendar.today");

Route::get("naptar/tegnap",
    [CalendarController::class, "yesterday"])
        ->name("calendar.yesterday");

Route::get("naptar/holnap",
    [CalendarController::class, "tomorrow"])
        ->name("calendar.tomorrow");