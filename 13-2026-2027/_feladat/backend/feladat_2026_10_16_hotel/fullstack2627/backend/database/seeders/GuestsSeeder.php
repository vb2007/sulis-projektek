<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class GuestsSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        DB::table('guests')->insert([
            [
                'name' => 'John Billionaire',
                'date_of_birth' => '1985-04-12',
                'regular' => true,
            ],
            [
                'name' => 'Emma Ellison',
                'date_of_birth' => '1992-09-23',
                'regular' => false,
            ],
            [
                'name' => 'Michael Zuckerberg',
                'date_of_birth' => '1978-01-30',
                'regular' => true,
            ],
            [
                'name' => 'Yi Long Ma',
                'date_of_birth' => '1968-06-15',
                'regular' => false,
            ],
        ]);
    }
}
