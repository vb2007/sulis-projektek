<?php

namespace App\Http\Controllers;

use Illuminate\Http\JsonResponse;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class HeroContentController extends Controller
{
    public function index() : JsonResponse
    {
        $build = DB::table("hero_contents");
        
        return response() -> json([
            "data" => $build->get()
        ]);
    }
}
