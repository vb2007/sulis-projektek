<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class ClientSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        DB::table('clients')->insert([
            [
                'name' => 'Lucia Caminos',
                'birth_date' => '1997-08-14',
                'birth_place' => 'Vice City, Leonida',
                'ssn_last_4_digits' => '4829',
            ],
            [
                'name' => 'Jason Duval',
                'birth_date' => '1994-03-22',
                'birth_place' => 'Port Gellhorn, Leonida',
                'ssn_last_4_digits' => '7104',
            ],
            [
                'name' => 'Stefanie Morales',
                'birth_date' => '1982-11-05',
                'birth_place' => 'Hamlet, Leonida',
                'ssn_last_4_digits' => '3391',
            ],
            [
                'name' => 'Carlos Mendoza',
                'birth_date' => '1988-06-19',
                'birth_place' => 'Vice Beach, Leonida',
                'ssn_last_4_digits' => '9052',
            ],
            [
                'name' => 'Tamara Vance',
                'birth_date' => '1999-02-11',
                'birth_place' => 'Starfish Island, Leonida',
                'ssn_last_4_digits' => '1648',
            ],
            [
                'name' => 'Boobie Ike',
                'birth_date' => '1985-09-30',
                'birth_place' => 'Cottonmouth, Leonida',
                'ssn_last_4_digits' => '8473',
            ],
            [
                'name' => 'Darnell Jackson',
                'birth_date' => '1991-12-03',
                'birth_place' => 'Little Haiti, Vice City',
                'ssn_last_4_digits' => '5219',
            ],
            [
                'name' => 'Mateo Rivera',
                'birth_date' => '1996-04-27',
                'birth_place' => 'Little Havana, Vice City',
                'ssn_last_4_digits' => '6730',
            ],
            [
                'name' => 'Billy Ray Clemons',
                'birth_date' => '1976-07-08',
                'birth_place' => 'Grassrivers, Leonida',
                'ssn_last_4_digits' => '2984',
            ],
            [
                'name' => 'Valeria Gomez',
                'birth_date' => '2000-01-15',
                'birth_place' => 'Ocean Beach, Vice City',
                'ssn_last_4_digits' => '9411',
            ],
            [
                'name' => 'Marcus Sterling',
                'birth_date' => '1979-10-21',
                'birth_place' => 'Ambrosia, Leonida',
                'ssn_last_4_digits' => '3805',
            ],
            [
                'name' => 'Elena Rostova',
                'birth_date' => '1993-05-12',
                'birth_place' => 'Viceport, Leonida',
                'ssn_last_4_digits' => '7562',
            ],
            [
                'name' => 'Cletus Boone',
                'birth_date' => '1984-08-29',
                'birth_place' => 'Kelly County, Leonida',
                'ssn_last_4_digits' => '1190',
            ],
            [
                'name' => 'Desiree Washington',
                'birth_date' => '1995-11-18',
                'birth_place' => 'Washington Beach, Vice City',
                'ssn_last_4_digits' => '6047',
            ],
            [
                'name' => 'Hector Delgado',
                'birth_date' => '1981-03-04',
                'birth_place' => 'Leonard County, Leonida',
                'ssn_last_4_digits' => '8823',
            ],
        ]);
    }
}
