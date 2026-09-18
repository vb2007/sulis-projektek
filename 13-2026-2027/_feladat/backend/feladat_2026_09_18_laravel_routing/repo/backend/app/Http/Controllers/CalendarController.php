<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class CalendarController extends Controller
{
    public function today() {
        return ["data" =>  ["title" => "Ma",
                             "date" => date("Y-m-d")]];
    }
}
