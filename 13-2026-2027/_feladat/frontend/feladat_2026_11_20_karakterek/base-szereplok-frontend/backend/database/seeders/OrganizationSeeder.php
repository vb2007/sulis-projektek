<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class OrganizationSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        DB::table('organizations')->insert([
            [
                'id' => 1,
                'name' => "Brian's Boat Works & Marina",
                'type' => 'Kikötő',
                'area' => 'Leonida Keys',
            ],
            [
                'id' => 2,
                'name' => 'Only Raw Records',
                'type' => 'Lemezkiadó',
                'area' => 'Vice City',
            ],
            [
                'id' => 3,
                'name' => 'Jack of Hearts',
                'type' => 'Klub',
                'area' => 'Vice City',
            ],
            [
                'id' => 4,
                'name' => 'Vice City Police Department',
                'type' => 'Rendvédelmi szervezet',
                'area' => 'Vice City',
            ],
            [
                'id' => 5,
                'name' => 'Független',
                'type' => null,
                'area' => 'Leonida Állam',
            ],
        ]);
    }
}
