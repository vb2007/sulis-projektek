<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class ProductSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        DB::table("products")->insert([
            [
                [
                    "id" => "1",
                    "name" => "Kenyér",
                    "price" => "762.00",
                    "unit" => "kg",
                    "vat" => "0.18",
                    "image" => "bread.png",
                ],
                [
                    "id" => "2",
                    "name" => "Csokoládés muffin",
                    "price" => "393.00",
                    "unit" => "piece",
                    "vat" => "0.27",
                    "image" => "chocolate-cupcake.png",
                ],
                [
                    "id" => "3",
                    "name" => "Croissant",
                    "price" => "338.00",
                    "unit" => "piece",
                    "vat" => "0.18",
                    "image" => "croissant.png",
                ],
                [
                    "id" => "4",
                    "name" => "Félbarna kenyér",
                    "price" => "677.00",
                    "unit" => "kg",
                    "vat" => "0.18",
                    "image" => "hard-dough-bread.png",
                ],
                [
                    "id" => "5",
                    "name" => "Vizes zsemle",
                    "price" => "75.00",
                    "unit" => "piece",
                    "vat" => "0.18",
                    "image" => "hard-dough-roll.png",
                ],
                [
                    "id" => "6",
                    "name" => "Hot dog kifli",
                    "price" => "126.00",
                    "unit" => "piece",
                    "vat" => "0.18",
                    "image" => "hot-dog-bun.png",
                ],
                [
                    "id" => "7",
                    "name" => "Hosszúkás kifli",
                    "price" => "109.00",
                    "unit" => "piece",
                    "vat" => "0.18",
                    "image" => "long-hard-dough-roll.png",
                ],
                [
                    "id" => "8",
                    "name" => "Mini fahéjas csiga",
                    "price" => "472.00",
                    "unit" => "pack",
                    "vat" => "0.27",
                    "image" => "mini-cinnamon-rolls.png",
                ],
                [
                    "id" => "9",
                    "name" => "Pain au chocolat",
                    "price" => "393.00",
                    "unit" => "piece",
                    "vat" => "0.27",
                    "image" => "pain-au-chocolat.png",
                ],
                [
                    "id" => "10",
                    "name" => "Zsemle",
                    "price" => "67.00",
                    "unit" => "piece",
                    "vat" => "0.18",
                    "image" => "roll.png",
                ],
                [
                    "id" => "11",
                    "name" => "Szardíniás kenyér",
                    "price" => "550.00",
                    "unit" => "piece",
                    "vat" => "0.27",
                    "image" => "sardine-bread.png",
                ],
                [
                    "id" => "12",
                    "name" => "Mázas fánk",
                    "price" => "393.00",
                    "unit" => "piece",
                    "vat" => "0.27",
                    "image" => "glazed-donut.png",
                ],
            ],
        ]);
    }
}
