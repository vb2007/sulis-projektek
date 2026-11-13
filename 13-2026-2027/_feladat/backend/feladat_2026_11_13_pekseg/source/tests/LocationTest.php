<?php

namespace Tests\Feature;

use App\Models\Location;
use Database\Factories\LocationFactory;
use Database\Seeders\LocationSeeder;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\SoftDeletes;
use Illuminate\Foundation\Testing\RefreshDatabase;
use Illuminate\Foundation\Testing\WithFaker;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Schema;
use Illuminate\Testing\Fluent\AssertableJson;
use Tests\TestCase;

class LocationTest extends TestCase
{
    use RefreshDatabase;
    
    public function test_locations_table_id_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('locations', 'id'), 'A locations tábla id mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('locations', 'id'), 'integer', 'A locations tábla id mezője nem megfelelő típusú!');
        $this->assertEquals(collect(Schema::getIndexes('locations'))->firstWhere('name', 'primary')['columns'], ['id'], 'A locations tábla id mezője nem elsődleges kulcs!');
    }
    
    public function test_locations_table_name_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('locations', 'address'), 'A locations tábla address mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('locations', 'address'), 'varchar', 'A locations tábla address mezője nem megfelelő típusú!');
    }
    
    public function test_locations_table_opening_time_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('locations', 'opening_time'), 'A locations tábla opening_time mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('locations', 'opening_time'), 'time', 'A locations tábla opening_time mezője nem megfelelő típusú!');
        $this->assertTrue(collect(Schema::getColumns('locations'))->firstWhere('name', 'opening_time')['nullable'], 'A locations tábla opening_time mezője nem opcionális!');
    }
    
    public function test_locations_table_closing_time_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('locations', 'closing_time'), 'A locations tábla closing_time mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('locations', 'closing_time'), 'time', 'A locations tábla closing_time mezője nem megfelelő típusú!');
        $this->assertTrue(collect(Schema::getColumns('locations'))->firstWhere('name', 'closing_time')['nullable'], 'A locations tábla closing_time mezője nem opcionális!');
    }

    public function test_locations_table_image_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('locations', 'image'), 'A locations tábla image mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('locations', 'image'), 'varchar', 'A locations tábla image mezője nem megfelelő típusú!');
    }

    public function test_locations_table_timestamps_correct(): void {
        $this->assertTrue(Schema::hasColumn('locations', 'created_at'), 'A locations tábla created_at mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('locations', 'created_at'), 'datetime', 'A locations tábla created_at mezője nem megfelelő típusú!');
        $this->assertTrue(collect(Schema::getColumns('locations'))->firstWhere('name', 'created_at')['nullable'], 'A locations tábla created_at mezője nem opcionális!');
        $this->assertTrue(Schema::hasColumn('locations', 'updated_at'), 'A locations tábla updated_at mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('locations', 'updated_at'), 'datetime', 'A locations tábla updated_at mezője nem megfelelő típusú!');
        $this->assertTrue(collect(Schema::getColumns('locations'))->firstWhere('name', 'updated_at')['nullable'], 'A locations tábla updated_at mezője nem opcionális!');
    }

    public function test_locations_table_soft_deletes_correct(): void {
        $this->assertTrue(Schema::hasColumn('locations', 'deleted_at'), 'A locations tábla deleted_at mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('locations', 'deleted_at'), 'datetime', 'A locations tábla deleted_at mezője nem megfelelő típusú!');
        $this->assertTrue(collect(Schema::getColumns('locations'))->firstWhere('name', 'deleted_at')['nullable'], 'A locations tábla deleted_at mezője nem opcionális!');
    }

    public function test_location_model_exists(): void 
    {
        $this->assertTrue(class_exists(Location::class), 'Nem létezik a Location modell!');
    }

    public function test_location_model_traits_correct(): void 
    {
        $this->assertContains(HasFactory::class, class_uses(Location::class), 'A HasFactory trait nem található a Location modellen!');
        $this->assertContains(SoftDeletes::class, class_uses(Location::class), 'A SoftDeletes trait nem található a Location modellen!');
    }

    public function test_location_factory_exists(): void {
        $this->assertTrue(class_exists(LocationFactory::class), 'Nem létezik a LocationFactory osztály!');
        $location = Location::factory()->create();
        $this->assertModelExists($location);
    }

    public function test_location_factory_address_correct(): void {
        $location = Location::factory()->create();
        $this->assertIsString($location->address, 'A LocationFactory által generált helyszín address mezője nem megfelelő típusú!');
        $this->assertStringContainsString(', ', $location->address, 'A LocationFactory által generált helyszín address mezője nem tartalmaz vesszőt és utána szóközt!');
        $this->assertStringEndsWith('.', $location->address, 'A LocationFactory által generált helyszín address mezője nem tartalmaz a végén pontot!');
    }

    public function test_location_factory_opening_time_correct(): void {
        $locations = Location::factory()->count(1000)->make()->pluck('opening_time')->all();
        $nullOpening = array_filter($locations, fn($x) => is_null($x));
        $notNullOpening = array_filter($locations, fn($x) => !is_null($x));
        $this->assertContainsOnlyNull($nullOpening, 'A LocationFactory által generált adatok nem tartalmaznak null értékű opening_time mezőket!');
        $this->assertContainsOnlyString($notNullOpening, 'A LocationFactory által generált adatok nem tartalmaznak megfelelő típusú opening_time mezőket!');
        $allowedHours = ['04:00:00', '05:00:00', '06:00:00', '07:00:00', '08:00:00', '09:00:00', '10:00:00'];
        $invalidTimes = array_filter($notNullOpening, fn($time) => !in_array($time, $allowedHours, true));
        $this->assertEmpty($invalidTimes, 'A LocationFactory által generált adatok nem kizárólag a kritériumoknak megfelelő opening_time mezőket tartalmaznak!');
    }

    public function test_location_factory_closing_time_correct(): void {
        $locations = Location::factory()->count(1000)->make()->pluck('closing_time')->all();
        $notNullClosing = array_filter($locations, fn($x) => !is_null($x));
        $this->assertContainsOnlyString($notNullClosing, 'A LocationFactory által generált adatok nem tartalmaznak megfelelő típusú closing_time mezőket!');
        $allowedHours = ['18:00:00', '19:00:00', '20:00:00', '21:00:00', '22:00:00'];
        $invalidTimes = array_filter($notNullClosing, fn($time) => !in_array($time, $allowedHours, true));
        $this->assertEmpty($invalidTimes, 'A LocationFactory által generált adatok nem kizárólag a kritériumoknak megfelelő closing_time mezőket tartalmaznak!');
        $locations = Location::factory()->count(1000)->make();
        $nullOpening = $locations->filter(fn($x) => is_null($x->opening_time))->pluck('closing_time')->all();
        $this->assertContainsOnlyNull($nullOpening, 'A LocationFactory által generált adatokban a closing_time nem null ott, ahol az opening_time null!');
    }

    public function test_location_factory_image_correct(): void {
        $location = Location::factory()->create();
        $this->assertModelExists($location);
        $this->assertIsString($location->image, 'A LocationFactory által generált helyszín image mezője nem megfelelő típusú!');
        $this->assertMatchesRegularExpression('/^(bakery-)([0-9])(.jpeg)$/', $location->image, 'A LocationFactory által generált helyszín image mezője nem megfelelő formátumú!');
    }

    public function test_location_seeder_correct(): void
    {
        $this->seed(LocationSeeder::class);
        $this->assertDatabaseCount('locations', 30);
    }

    public function test_making_a_get_request_to_locations_index(): void {
        $location = Location::factory()->create();
        Location::factory()->count(9)->create();
        $response = $this->getJson('/api/locations');
        $response->assertStatus(200)
            ->assertJson(
                fn (AssertableJson $json) =>
                    $json->has('data', 10)
                        ->has('data.0', fn (AssertableJson $json) =>
                            $json->where('id', $location->id)
                                ->where('address', $location->address)
                                ->where('opening_time', $location->opening_time)
                                ->where('closing_time', $location->closing_time)
                                ->where('image', env('APP_URL', 'http://backend.vm1.test') . "/images/locations/{$location->image}")
                                ->missing('created_at')
                                ->missing('updated_at')
                                ->missing('deleted_at')
                        )
            );
    }

    public function test_making_a_get_request_with_query_string_to_locations_index(): void {
        $location = Location::factory()->create(['address' => 'bécs']);
        Location::factory()->create(['address' => 'bécsújhely']);
        Location::factory()->count(9)->create();
        $response = $this->getJson('/api/locations?city=bécs');
        $response->assertStatus(200)
            ->assertJson(
                fn (AssertableJson $json) =>
                    $json->has('data', 2)
                        ->has('data.0', fn (AssertableJson $json) =>
                            $json->where('id', $location->id)
                                ->where('address', $location->address)
                                ->where('opening_time', $location->opening_time)
                                ->where('closing_time', $location->closing_time)
                                ->where('image', env('APP_URL', 'http://backend.vm1.test') . "/images/locations/{$location->image}")
                                ->missing('created_at')
                                ->missing('updated_at')
                                ->missing('deleted_at')
                        )
            );
    }

    public function test_making_a_get_request_to_locations_show(): void {
        $location = Location::factory()->create();
        $response = $this->getJson('/api/locations/' . $location->id);
        $response->assertStatus(200)
            ->assertJson(
                fn (AssertableJson $json) =>
                    $json->has('data', fn (AssertableJson $json) =>
                                $json->where('id', $location->id)
                                    ->where('address', $location->address)
                                    ->where('opening_time', $location->opening_time)
                                    ->where('closing_time', $location->closing_time)
                                    ->where('image', env('APP_URL', 'http://backend.vm1.test') . "/images/locations/{$location->image}")
                                ->missing('created_at')
                                ->missing('updated_at')
                                ->missing('deleted_at')
                        )
            );
    }

    public function test_making_a_get_request_for_non_existent_model_to_locations_show(): void {
        $response = $this->getJson('/api/locations/1');
        $response->assertStatus(404);
    }
}
