<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class CharacterSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        DB::table('characters')->insert([
            [
                'name' => 'Jason Duval',
                'type' => 'Főszereplő',
                'occupation' => 'Csempész',
                'description' => 'A Leonida Keys területén tevékenykedő drogcsempész. Fiatalkorában gyakran keveredett bajba, majd az amerikai hadseregben próbált új életet kezdeni, de végül visszatért a bűnözéshez Brian Heder oldalán.',
                'image' => 'jason_duval.webp',
                'organization_id' => 1,
                'created_at' => now(),
                'updated_at' => now(),
            ],
            [
                'name' => 'Lucia Caminos',
                'type' => 'Főszereplő',
                'occupation' => 'Bűnöző',
                'description' => 'Hispanik származású bűnöző, aki korábban Liberty Cityben élt. Családja védelme érdekében keveredett harcba, ami miatt a 2020-as évek közepén a Leonida állami fegyházba került. Szabadulása után új életet tervez Jasonnel.',
                'image' => 'lucia_caminos.webp',
                'organization_id' => 5,
                'created_at' => now(),
                'updated_at' => now(),
            ],
            [
                'name' => 'Brian Heder',
                'type' => 'mellékszereplő',
                'occupation' => 'Kikötőtulajdonos',
                'description' => 'Tapasztalt drogcsempész a Leonida Keys vidékén, aki a Brian\'s Boat Works & Marina kikötőből irányítja üzleteit. A piszkos munkát már embereire, Jasonre és Calre bízza. Jelenleg harmadik feleségével, Lorival él.',
                'image' => 'brian_heder.webp',
                'organization_id' => 1,
                'created_at' => now(),
                'updated_at' => now(),
            ],
            [
                'name' => 'Cal Hampton',
                'type' => 'mellékszereplő',
                'occupation' => 'Csempész',
                'description' => 'Jason barátja és Brian Heder társa. Paranoiás és összeesküvés-elmélet hívő; szabadidejében a parti őrség kommunikációját hallgatja le, internetes teóriákat olvas és a madarak repülési alakzatait figyeli.',
                'image' => 'cal_hampton.webp',
                'organization_id' => 1,
                'created_at' => now(),
                'updated_at' => now(),
            ],
            [
                'name' => 'Boobie Ike',
                'type' => 'mellékszereplő',
                'occupation' => 'Klubtulajdonos',
                'description' => 'Ingatlanmágnás, zenei producer és a Jack of Hearts klub tulajdonosa. Alapvetően barátságos, de az üzletben kíméletlen. Legfőbb célja, hogy az Only Raw Records stúdióval befutott lemezszerződést hozzon össze.',
                'image' => 'boobie_ike.webp',
                'organization_id' => 3,
                'created_at' => now(),
                'updated_at' => now(),
            ],
            [
                'name' => 'Dre\'Quan Priest',
                'type' => 'mellékszereplő',
                'occupation' => 'Producer',
                'description' => 'Feltörekvő előadó és Boobie Ike üzlettársa az Only Raw Records kiadónál. Korábbi utcai díler, akinek mindig a zene volt a szenvedélye. Ő szerződtette le a Real Dimez duót, célja pedig Vice City zenei életének meghódítása.',
                'image' => 'dre_quan_priest.webp',
                'organization_id' => 2,
                'created_at' => now(),
                'updated_at' => now(),
            ],
            [
                'name' => 'Bae-Luxe',
                'type' => 'mellékszereplő',
                'occupation' => 'Rapper',
                'description' => 'A Real Dimez rapduó egyik tagja. Középiskola óta barátok; kezdetben helyi drogdílereket húztak le, mielőtt a közösségi médián keresztül betörtek a zeneiparba.',
                'image' => 'bae_luxe.webp',
                'organization_id' => 2,
                'created_at' => now(),
                'updated_at' => now(),
            ],
            [
                'name' => 'Roxy',
                'type' => 'mellékszereplő',
                'occupation' => 'Rapper',
                'description' => 'A Real Dimez rapduó egyik tagja. Öt évvel ezelőtt egy helyi rapperrel, DWNPLY-jal közös slágerük tette őket népszerűvé. Miután bajba keveredtek, Dre\'Quan Priest révén az Only Raw Recordshoz szerződtek egy újabb siker reményében.',
                'image' => 'roxy.webp',
                'organization_id' => 2,
                'created_at' => now(),
                'updated_at' => now(),
            ],
            [
                'name' => 'Raul Bautista',
                'type' => 'mellékszereplő',
                'occupation' => 'Bankrabló',
                'description' => 'Vice Cityben tevékenykedő, tapasztalt bankrabló. Sármjáról és vakmerőségéről ismert, aki folyamatosan a következő nagy dobást tervezi, és új tehetségeket keres a csapatába.',
                'image' => 'raul_bautista.webp',
                'organization_id' => 5,
                'created_at' => now(),
                'updated_at' => now(),
            ],
            [
                'name' => 'Méndez',
                'type' => 'mellékszereplő',
                'occupation' => 'Rendőr',
                'description' => 'A Vice City Police Department (VCPD) különleges munkacsoportjának vezetője, aki rajtaütéseket és házkutatásokat irányít erőszakos bűnözők ellen. A történet során többször is összetűzésbe kerül Jasonnel és Luciával.',
                'image' => 'mendez.webp',
                'organization_id' => 4,
                'created_at' => now(),
                'updated_at' => now(),
            ],
        ]);
    }
}
