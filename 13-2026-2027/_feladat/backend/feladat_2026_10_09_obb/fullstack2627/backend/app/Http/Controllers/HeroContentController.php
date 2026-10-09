<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class HeroContentController extends Controller
{
    public function index()
    {
        $build = DB::table("hero_contents");
        return response() -> json([
            "data" => $build->get()
        ]);
    }
}
