<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class HelicoptersSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        DB::table('helicopters')->insert([
            [
                'guest_id' => 4,
                'manufacturer' => 'Robinson',
                'model' => 'R44',
                'year' => 2019,
                'color' => 'Red',
                'passenger_capacity' => 4,
                'max_velocity' => 240,
                'range' => 560,
                'price' => 210000,
                'twin_engine' => false,
                'from' => '2026-10-21 10:00:00',
                'to' => '2026-10-21 17:00:00',
            ],
            [
                'guest_id' => 2,
                'manufacturer' => 'Bell',
                'model' => '429',
                'year' => 2023,
                'color' => 'White',
                'passenger_capacity' => 7,
                'max_velocity' => 278,
                'range' => 761,
                'price' => 480000,
                'twin_engine' => true,
                'from' => '2026-10-14 09:00:00',
                'to' => '2026-10-14 18:00:00',
            ],
            [
                'guest_id' => 3,
                'manufacturer' => 'Leonardo',
                'model' => 'AW109',
                'year' => 2020,
                'color' => 'Grey',
                'passenger_capacity' => 7,
                'max_velocity' => 311,
                'range' => 932,
                'price' => 520000,
                'twin_engine' => true,
                'from' => '2026-10-17 07:00:00',
                'to' => '2026-10-17 16:00:00',
            ],
            [
                'guest_id' => 1,
                'manufacturer' => 'Airbus',
                'model' => 'H125',
                'year' => 2021,
                'color' => 'Black',
                'passenger_capacity' => 6,
                'max_velocity' => 287,
                'range' => 630,
                'price' => 350000,
                'twin_engine' => false,
                'from' => '2026-10-11 08:00:00',
                'to' => '2026-10-11 15:00:00',
            ],
        ]);
    }
}
