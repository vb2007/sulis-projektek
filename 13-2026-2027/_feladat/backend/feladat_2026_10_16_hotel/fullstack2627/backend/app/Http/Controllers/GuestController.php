<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class GuestController extends Controller
{
    public function index()
    {
        $data = DB::table("guests")
            ->whereNull("deleted_at")
            ->get();

        return response()->json(["data" => $data]);
    }

    public function show(string $guest)
    {
        if (!is_numeric($guest) || $guest <= 0) {
            return response()->json([
                "message" => "Az azonosító csak pozitív szám lehet!"
            ], 500);
        }

        $data = DB::table("guests")
            ->where("id", $guest)
            ->whereNull("deleted_at")
            ->first();

        if (!$data) {
            return response()->json([
                "message" => "A megadott azonosítóval nem található vendég!"
            ], 404);
        }

        return response()->json(["data" => $data]);
    }
}
