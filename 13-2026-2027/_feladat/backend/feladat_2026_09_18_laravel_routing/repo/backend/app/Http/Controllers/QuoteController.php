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

    public function harryPotter(string $slug){
        switch ($slug)
        {
            case "fred-es-george":
                return ["data" =>  ["title" => "Harry Potter",
                                     "quote" => "- Mindig is tudtuk hol a határ - bólintott Fred - És csak óvatosan léptük át - tette hozzá George.",
                                     "name" => "Fred és George"]];
            case "fentfloyd":
                return ["data" =>  ["title" => "Under the knee",
                                     "quote" => "I can't breathe, I'm high on fent n' shiee.",
                                     "name" => "Fent Floyd"]];
            case "hermione":
                return ["data" =>  ["title" => "Harry Potter",
                                     "quote" => "Még egy ilyen remek ötlet, és mindhárman meghalunk, vagy akár ki is csaphatnak!",
                                     "name" => "Hermione"]];
            default:
                abort(404);
        }
    }
}
