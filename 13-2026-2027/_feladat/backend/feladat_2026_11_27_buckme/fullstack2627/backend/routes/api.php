<?php

use App\Http\Controllers\AccountController;
use App\Http\Controllers\ClientController;
use App\Http\Controllers\TransactionController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

Route::get('/user', function (Request $request) {
    return $request->user();
})->middleware('auth:sanctum');

//Clients
Route::get("/clients", [ClientController::class, "index"])
    ->name("clients.index");

Route::post("/clients", [ClientController::class, "store"])
    ->name("clients.store");

Route::get("/clients/{client}", [ClientController::class, "show"])
    ->name("clients.show");

Route::put("/clients/{client}", [ClientController::class, "update"])
    ->name("clients.update");

Route::delete("/clients/{client}", [ClientController::class, "destory"])
    ->name("clients.destory");

//Accounts
Route::get("/accounts", [AccountController::class, "index"])
    ->name("accounts.index");

Route::post("/accounts", [AccountController::class, "store"])
    ->name("accounts.store");

Route::get("/accounts/{account}", [AccountController::class, "show"])
    ->name("accounts.show");

Route::put("/accounts/{account}", [AccountController::class, "update"])
    ->name("accounts.update");

Route::delete("/accounts/{account}", [AccountController::class, "destory"])
    ->name("accounts.destory");

//Transactions
Route::get("/transactions", [TransactionController::class, "index"])
    ->name("transactions.index");

Route::post("/transactions", [TransactionController::class, "store"])
    ->name("transactions.store");

Route::get("/transactions/{transaction}", [TransactionController::class, "show"])
    ->name("transactions.show");