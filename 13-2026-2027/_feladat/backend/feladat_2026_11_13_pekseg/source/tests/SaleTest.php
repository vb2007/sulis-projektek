<?php

namespace Tests\Feature;

use App\Models\Sale;
use Database\Factories\SaleFactory;
use Database\Seeders\SaleSeeder;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Foundation\Testing\RefreshDatabase;
use Illuminate\Foundation\Testing\WithFaker;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Schema;
use Illuminate\Testing\Fluent\AssertableJson;
use Tests\TestCase;

class SaleTest extends TestCase
{
    use RefreshDatabase;

    private function create_locations(): void {
        DB::table('locations')->insert([
            [ 'id' => 1, 'address' => '', 'image' => '' ],
            [ 'id' => 2, 'address' => '', 'image' => '' ],
            [ 'id' => 3, 'address' => '', 'image' => '' ],
            [ 'id' => 4, 'address' => '', 'image' => '' ],
            [ 'id' => 5, 'address' => '', 'image' => '' ],
        ]);
    }

    public function test_sales_table_id_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('sales', 'id'), 'A sales tábla id mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('sales', 'id'), 'integer', 'A sales tábla id mezője nem megfelelő típusú!');
        $this->assertEquals(collect(Schema::getIndexes('sales'))->firstWhere('name', 'primary')['columns'], ['id'], 'A locations tábla id mezője nem elsődleges kulcs!');
    }

    public function test_sales_table_date_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('sales', 'date'), 'A sales tábla date mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('sales', 'date'), 'date', 'A sales tábla date mezője nem megfelelő típusú!');
    }

    public function test_sales_table_location_id_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('sales', 'location_id'), 'A sales tábla location_id mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('sales', 'location_id'), 'integer', 'A sales tábla location_id mezője nem megfelelő típusú!');
        $fk = Schema::getForeignKeys('sales')[0];
        $this->assertEquals($fk['columns'][0], 'location_id', 'A sales tábla location_id mezőjének idegen kulcs megszorítása nem megfelelő!');
        $this->assertEquals($fk['foreign_table'], 'locations', 'A sales tábla location_id mezőjének idegen kulcs megszorítása nem megfelelő!');
        $this->assertEquals($fk['foreign_columns'][0], 'id', 'A sales tábla location_id mezőjének idegen kulcs megszorítása nem megfelelő!');
    }

    public function test_sales_table_revenue_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('sales', 'revenue'), 'A sales tábla revenue mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('sales', 'revenue'), 'numeric', 'A sales tábla revenue mezője nem megfelelő típusú!');
        $this->assertTrue(collect(Schema::getColumns('sales'))->firstWhere('name', 'revenue')['nullable'], 'A sales tábla revenue mezője nem opcionális!');
    }

    public function test_sale_model_exists(): void 
    {
        $this->assertTrue(class_exists(Sale::class), 'Nem létezik a Sale modell!');
    }

    public function test_sale_model_traits_correct(): void 
    {
        $this->assertContains(HasFactory::class, class_uses(Sale::class), 'A HasFactory trait nem található a Sale modellen!');
    }

    public function test_sale_factory_exists(): void {
        $this->assertTrue(class_exists(SaleFactory::class), 'Nem létezik a SaleFactory osztály!');
        $this->create_locations();
        $sale = Sale::factory()->create();
        $this->assertModelExists($sale);
    }

    public function test_sale_factory_date_correct(): void {
        $this->create_locations();
        $sales = Sale::factory()->count(1000)->make()->pluck('date')->all();
        $incorrect = array_filter($sales, fn($x) => !preg_match('/^2026\-((10\-(1[0-9]|2[0-9]|3[01]))|(11\-0[1-5]))$/', $x));
        $this->assertEmpty($incorrect, 'A SaleFactory által generál eladásoknál van olyan, ahol nem megfelelő a date mező!');
    }

    public function test_sale_factory_location_id_correct(): void {
        $this->create_locations();
        $locations = Sale::factory()->count(20)->make()->unique('location_id')->pluck('location_id')->all();
        foreach ($locations as $id) $this->assertDatabaseHas('locations', ['id' => $id]);
    }

    public function test_sale_factory_revenue_correct(): void {
        $this->create_locations();
        $sales = Sale::factory()->count(1000)->make()->pluck('revenue')->all();
        $incorrect = array_filter($sales, fn($x) => $x < 30000 || $x > 50000);
        $this->assertEmpty($incorrect, 'A SaleFactory által generál eladásoknál van olyan, ahol nem megfelelő a revenue mező!');
    }

    public function test_sale_seeder_correct(): void
    {
        $this->create_locations();
        $this->seed(SaleSeeder::class);
        $this->assertDatabaseCount('sales', 250);
        $this->assertDatabaseHas('sales', ['revenue' => null]);
    }

    public function test_making_a_get_request_to_sales_index(): void {
        $this->create_locations();
        $sale = Sale::factory()->create();
        Sale::factory()->count(9)->create();
        $response = $this->getJson('/api/sales');
        $response->assertStatus(200)
            ->assertJson(
                fn (AssertableJson $json) =>
                    $json->has('data', 10)
                        ->has('data.0', fn (AssertableJson $json) =>
                            $json->where('id', $sale->id)
                                ->where('date', $sale->date)
                                ->where('location_id', $sale->location_id)
                                ->where('revenue', $sale->revenue)
                        )
            );
    }

    public function test_making_a_get_request_to_sales_show(): void {
        $this->create_locations();
        $sale = Sale::factory()->create();
        $response = $this->getJson('/api/sales/' . $sale->id);
        $response->assertStatus(200)
            ->assertJson(
                fn (AssertableJson $json) =>
                    $json->has('data', fn (AssertableJson $json) =>
                        $json->where('id', $sale->id)
                            ->where('date', $sale->date)
                            ->where('location_id', $sale->location_id)
                            ->where('revenue', $sale->revenue)
                    )
            );
    }

    public function test_making_a_get_request_for_non_existent_model_to_sales_show(): void {
        $response = $this->getJson('/api/sales/1');
        $response->assertStatus(404);
    }

    public function test_making_a_get_request_to_sales_sum(): void {
        $this->create_locations();
        $sum = Sale::factory()->count(10)->create()->sum('revenue');
        $response = $this->getJson('/api/sales/sum');
        $response->assertStatus(200)
            ->assertJson([ 'data' => $sum ]);
    }

    public function test_making_a_get_request_with_query_string_to_sales_sum(): void {
        $this->create_locations();
        Sale::factory()->count(10)->create();
        DB::table('locations')->insert([[ 'id' => 67, 'address' => '', 'image' => '' ],]);
        $sum = Sale::factory()->count(10)->create([ 'date' => '2026-11-06', 'location_id' => 67, ])->sum('revenue');
        $response1 = $this->getJson('/api/sales/sum?date=2026-11-06');
        $response1->assertStatus(200)
            ->assertJson([ 'data' => $sum ]);
        $response2 = $this->getJson('/api/sales/sum?location_id=67');
        $response2->assertStatus(200)
            ->assertJson([ 'data' => $sum ]);
        $response3 = $this->getJson('/api/sales/sum?date=2026-11-06&location_id=67');
        $response3->assertStatus(200)
            ->assertJson([ 'data' => $sum ]);
    }
}
