<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

use App\Http\Controllers\QuoteController;
use App\Http\Controllers\CalendarController;
use App\Http\Controllers\CalculatorController;

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

//CalculatorController

Route::get('szamologep/{a}{operator}{b}',
    [CalculatorController::class, 'result'])
        ->where([
            'a' => '[0-9]+',
            'operator' => '[+\-*/]',
            'b' => '[0-9]+',
        ])
        ->name('calculator.result');

// CalendarController (hét napjai)

Route::get("hetnapja/{number}",
    [CalendarController::class, "weekdayName"])
        ->where([
            'number' => '[1-7]', // csak számot PLUSZ CSAK 1-7
        ])
        ->name("calendar.weekdayName");