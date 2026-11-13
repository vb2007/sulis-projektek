<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class CalendarController extends Controller
{
    protected $weekdays = [
        "hétfő",
        "kedd",
        "szerda",
        "csütörtök",
        "péntek",
        "szombat",
        "vasárnap"
    ];

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

    public function weekdayName(int $number)
    {
        $weekdayIndex = $number - 1; // 1-7
        return ["data" => $this->weekdays[$weekdayIndex]];
    }

    public function weekdayNumber(string $name)
    {
        $index = array_search($name, $this->weekdays);

        if ($index === false) {
            return ["data" => null];
        }

        return ["data" => $index + 1]; // 1-7
    }
}
