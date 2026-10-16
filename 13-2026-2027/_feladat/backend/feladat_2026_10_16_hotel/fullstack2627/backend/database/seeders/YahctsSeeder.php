<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class YahctsSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        DB::table('yachts')->insert([
            [
                'guest_id' => 3,
                'manufacturer' => 'Azimut',
                'model' => 'Grande 27',
                'sailing' => false,
                'year' => 2024,
                'color' => 'White',
                'price' => 980000,
                'from' => '2026-10-20 09:00:00',
                'to' => '2026-10-24 20:00:00',
                'name' => 'Royal Wave',
            ],
            [
                'guest_id' => 1,
                'manufacturer' => 'Sunseeker',
                'model' => 'Predator 74',
                'sailing' => false,
                'year' => 2022,
                'color' => 'White',
                'price' => 750000,
                'from' => '2026-10-10 12:00:00',
                'to' => '2026-10-14 12:00:00',
                'name' => 'Ocean Dream',
            ],
            [
                'guest_id' => 4,
                'manufacturer' => 'Jeanneau',
                'model' => 'Sun Odyssey 440',
                'sailing' => true,
                'year' => 2020,
                'color' => 'White',
                'price' => 390000,
                'from' => '2026-10-25 08:00:00',
                'to' => '2026-10-28 18:00:00',
                'name' => 'Sea Breeze',
            ],
            [
                'guest_id' => 2,
                'manufacturer' => 'Beneteau',
                'model' => 'Oceanis 46',
                'sailing' => true,
                'year' => 2021,
                'color' => 'Blue',
                'price' => 420000,
                'from' => '2026-10-15 10:00:00',
                'to' => '2026-10-19 18:00:00',
                'name' => 'Blue Horizon',
            ],
        ]);
    }
}
