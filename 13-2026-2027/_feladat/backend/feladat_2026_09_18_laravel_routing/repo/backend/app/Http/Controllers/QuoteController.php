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

    public function uvegtigrisCsoki() {
        return ["data" =>  ["title" => "Üvegtigris",
                             "quote" => "Mennyire vagy túsz? Sörhöz odaférsz?",
                             "name" => "Csoki"]];
    }

    public function uvegtigrisLali() {
        return ["data" =>  ["title" => "Üvegtigris",
                             "quote" => "Az egybubis az egy kicsit drágább, mert hát abból ki kellett vennem a többi bubit.",
                             "name" => "Lali"]];
    }
}
