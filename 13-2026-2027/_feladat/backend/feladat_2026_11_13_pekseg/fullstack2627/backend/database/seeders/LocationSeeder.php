<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class LocationSeeder extends Seeder
{
    public function run(): void
    {
        $locations = [];

        for ($i = 0; $i < 10; $i++) {
            $opening = fake()->boolean(10) ? null : sprintf('%02d:00', fake()->numberBetween(4, 10));
            $closing = $opening === null ? null : sprintf('%02d:00', fake()->numberBetween(18, 22));

            $locations[] = [
                'address' => fake()->city() . ', ' . fake()->streetName() . ' ' . fake()->buildingNumber() . '.',
                'opening_time' => $opening,
                'closing_time' => $closing,
                'image' => 'location-' . fake()->numberBetween(0, 9) . '.jpeg',
            ];
        }

        DB::table('locations')->insert($locations);
    }
}