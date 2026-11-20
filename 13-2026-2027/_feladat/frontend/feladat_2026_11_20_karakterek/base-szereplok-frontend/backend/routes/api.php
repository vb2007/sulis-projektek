<?php

use App\Http\Controllers\CharacterController;
use App\Http\Controllers\ImageController;
use App\Http\Controllers\OrganizationController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use Illuminate\Support\Facades\Storage;

Route::apiResources([
    'organizations' => OrganizationController::class,
    'characters' => CharacterController::class,
]);

Route::get('images', [ImageController::class, 'index']);