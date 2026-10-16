<?php

use App\Http\Controllers\CarController;
use App\Http\Controllers\GuestController;
use App\Http\Controllers\HelicopterController;
use App\Http\Controllers\YachtController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

Route::get('/user', function (Request $request) {
    return $request->user();
})->middleware('auth:sanctum');

Route::prefix('hotel')->group(function () {
    Route::get('/guests', [GuestController::class, 'index'])->name('guests.index');
    Route::get('/guests/{guest}', [GuestController::class, 'show'])->name('guests.show');

    Route::get('/cars', [CarController::class, 'index'])->name('cars.index');
    Route::get('/cars/most_expensive', [CarController::class, 'most_expensive'])->name('cars.most_expensive');
    Route::get('/cars/{car}', [CarController::class, 'show'])->name('cars.show');

    Route::get('/yachts', [YachtController::class, 'index'])->name('yachts.index');
    Route::get('/yachts/sailing', [YachtController::class, 'sailing'])->name('yachts.sailing');
    Route::get('/yachts/{yacht}', [YachtController::class, 'show'])->name('yachts.show');

    Route::get('/helicopters', [HelicopterController::class, 'index'])->name('helicopters.index');
    Route::get('/helicopters/{min}/{max}', [HelicopterController::class, 'range'])->name('helicopters.range');
    Route::get('/helicopters/{helicopter}', [HelicopterController::class, 'show'])->name('helicopters.show');
});

