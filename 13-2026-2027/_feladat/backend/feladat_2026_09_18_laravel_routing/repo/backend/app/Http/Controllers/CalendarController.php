<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class CalendarController extends Controller
{
    public function today() {
        return ["data" =>  ["title" => "Ma",
                             "date" => date("Y-m-d")]];
    }

    public function yesterday() {
        return ["data" =>  ["title" => "Tegnap",
                             "date" => date("Y-m-d", strtotime("-1 day"))]];
    }

    public function tomorrow() {
        return ["data" =>  ["title" => "Holnap",
                             "date" => date("Y-m-d", strtotime("+1 day"))]];
    }
}
