<?php

namespace App\Http\Controllers;

use Illuminate\Http\JsonResponse;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class TeaserController extends Controller
{
    public function index(Request $request) : JsonResponse
    {
        $builder = DB::table("teasers");

        if ($request->has("section")) {
            $builder->where("section", $request->query("section"))
                ->orderBy("order");
        }

        return response() -> json([
            "data" => $builder->get()
        ]);
    }
}
