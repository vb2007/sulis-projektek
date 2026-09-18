<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class QuoteController extends Controller
{
    public function house() {
        return ["data" => ["title" => "House",
                          "quote" => "Nemcsak az emberek megalázásával lehet a gőzt kiereszteni; mondják, hogy a bowling jobb még ennél is.",
                          "name" => "Dr. House"]];
    }

    public function modernFamily() {
        return ["data" =>  ["title" => "Modern Család",
                             "quote" => "A siker mindig 1 százalék ihlet, plusz 98 százalék verejték, végül pedig 2 százalék odafigyelés.",
                             "name" => "Phil Dunphy"]];
    }
}
