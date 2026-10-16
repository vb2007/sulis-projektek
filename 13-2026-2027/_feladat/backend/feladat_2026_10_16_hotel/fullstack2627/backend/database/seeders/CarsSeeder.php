<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class CarsSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        DB::table('cars')->insert([
            [
                'guest_id' => 2,
                'manufacturer' => 'BMW',
                'model' => 'M4',
                'year' => 2024,
                'color' => 'Blue',
                'price' => 110000,
                'from' => '2026-10-13 08:00:00',
                'to' => '2026-10-15 20:00:00',
                'license_plate' => 'CD-EF-202',
            ],
            [
                'guest_id' => 1,
                'manufacturer' => 'Mercedes-Benz',
                'model' => 'S 500',
                'year' => 2023,
                'color' => 'Black',
                'price' => 95000,
                'from' => '2026-10-10 10:00:00',
                'to' => '2026-10-12 18:00:00',
                'license_plate' => 'AA-BB-101',
            ],
            [
                'guest_id' => 4,
                'manufacturer' => 'Tesla',
                'model' => 'Cybertruck',
                'year' => 2026,
                'color' => 'Black',
                'price' => 99990,
                'from' => '2026-10-20 12:00:00',
                'to' => '2026-10-22 12:00:00',
                'license_plate' => 'KL-MN-404',
            ],
            [
                'guest_id' => 3,
                'manufacturer' => 'Porsche',
                'model' => '911 Carrera',
                'year' => 2022,
                'color' => 'Red',
                'price' => 145000,
                'from' => '2026-10-16 09:00:00',
                'to' => '2026-10-18 17:00:00',
                'license_plate' => 'GH-IJ-303',
            ],
        ]);
    }
}
