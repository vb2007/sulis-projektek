<?php

require "src/Universe/Entities/Superhero.php";

use Universe\Entities\Superhero;

$superheroes = [
    new Superhero("Flash", 28, ["Speed", "Time Travel"]),
    new Superhero("Iron Man", 45, ["Genius Intellect", "Powered Armor Suit", "Wealth"]),
    new Superhero("Spider-Man", 18, ["Wall-Crawling", "Spider-Sense", "Super Agility"]),
    new Superhero("Superman", 35, ["Strength", "Flight", "X-ray Vision"]),
]
