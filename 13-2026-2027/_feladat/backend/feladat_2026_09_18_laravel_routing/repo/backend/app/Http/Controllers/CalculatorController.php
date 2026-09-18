<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class CalculatorController extends Controller
{
    public function result(string $a, string $operator, string $b)
    {
        $a = (int) $a;
        $b = (int) $b;

        if ($operator === '/' && $b === 0) {
            return response()->json([
                'message' => 'Nullával nem lehet osztani.',
            ], 400);
        }

        $title = match ($operator) {
            '+' => 'Összeadás',
            '-' => 'Kivonás',
            '*' => 'Szorzás',
            '/' => 'Osztás',
        };

        $result = match ($operator) {
            '+' => $a + $b,
            '-' => $a - $b,
            '*' => $a * $b,
            '/' => $a / $b,
        };

        return [
            'data' => [
                'title' => $title,
                'a' => $a,
                'b' => $b,
                'operator' => $operator,
                'result' => $result,
            ],
        ];
    }
}
