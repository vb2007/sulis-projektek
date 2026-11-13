<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class SaleSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        $locationIds = DB::table("locations")->pluck("id");

        $start = strtotime("2026-10-10");
        $end = strtotime("2026-11-05");
        $daySpan = (int) (($end - $start) / 86400);

        $sales = [];

        for ($i = 0; $i < 250; $i++) {
            $sales[] = [
                "date" => date("Y-m-d", strtotime("+" . random_int(0, $daySpan) . " days", $start)),
                "location_id" => $locationIds->random(),
                "revenue" => $i === 0 ? null : fake()->numberBetween(30000, 50000),
            ];
        }

        DB::table("sales")->insert($sales);
    }
}
