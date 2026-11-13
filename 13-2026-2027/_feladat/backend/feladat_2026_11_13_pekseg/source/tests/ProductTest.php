<?php

namespace Tests\Feature;

use App\Models\Product;
use Database\Seeders\ProductSeeder;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\SoftDeletes;
use Illuminate\Foundation\Testing\RefreshDatabase;
use Illuminate\Foundation\Testing\WithFaker;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Schema;
use Illuminate\Testing\Fluent\AssertableJson;
use Tests\TestCase;

class ProductTest extends TestCase
{
    use RefreshDatabase;

    public function test_products_table_id_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('products', 'id'), 'A products tábla id mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('products', 'id'), 'integer', 'A products tábla id mezője nem megfelelő típusú!');
        $this->assertEquals(collect(Schema::getIndexes('products'))->firstWhere('name', 'primary')['columns'], ['id'], 'A products tábla id mezője nem elsődleges kulcs!');
    }
    
    public function test_products_table_name_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('products', 'name'), 'A products tábla name mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('products', 'name'), 'varchar', 'A products tábla name mezője nem megfelelő típusú!');
    }
    
    public function test_products_table_price_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('products', 'price'), 'A products tábla price mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('products', 'price'), 'numeric', 'A products tábla price mezője nem megfelelő típusú!');
    }
    
    public function test_products_table_unit_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('products', 'unit'), 'A products tábla unit mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('products', 'unit'), 'varchar', 'A products tábla unit mezője nem megfelelő típusú!');
        $this->assertStringContainsString("check (\"unit\" in ('piece', 'kg', 'gram', 'pack', 'slice'))", DB::selectOne("SELECT sql FROM sqlite_master WHERE type='table' AND name='products'")->sql, 'A products tábla unit mezője nem csak a megadott értékeket veheti fel!');
    }

    public function test_products_table_vat_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('products', 'vat'), 'A products tábla vat mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('products', 'vat'), 'numeric', 'A products tábla vat mezője nem megfelelő típusú!');
        $this->assertEquals(collect(Schema::getColumns('products'))->firstWhere('name', 'vat')['default'], "'0.27'", 'A products tábla vat mezőjének alapértelmezett értéke nem megfelelő!');
    }

    public function test_products_table_image_field_correct(): void {
        $this->assertTrue(Schema::hasColumn('products', 'image'), 'A products tábla image mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('products', 'image'), 'varchar', 'A products tábla image mezője nem megfelelő típusú!');
    }

    public function test_products_table_timestamps_correct(): void {
        $this->assertTrue(Schema::hasColumn('products', 'created_at'), 'A products tábla created_at mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('products', 'created_at'), 'datetime', 'A products tábla created_at mezője nem megfelelő típusú!');
        $this->assertTrue(collect(Schema::getColumns('products'))->firstWhere('name', 'created_at')['nullable'], 'A products tábla created_at mezője nem opcionális!');
        $this->assertTrue(Schema::hasColumn('products', 'updated_at'), 'A products tábla updated_at mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('products', 'updated_at'), 'datetime', 'A products tábla updated_at mezője nem megfelelő típusú!');
        $this->assertTrue(collect(Schema::getColumns('products'))->firstWhere('name', 'updated_at')['nullable'], 'A products tábla updated_at mezője nem opcionális!');
    }

    public function test_products_table_soft_deletes_correct(): void {
        $this->assertTrue(Schema::hasColumn('products', 'deleted_at'), 'A products tábla deleted_at mezője nem létezik!');
        $this->assertEquals(Schema::getColumnType('products', 'deleted_at'), 'datetime', 'A products tábla deleted_at mezője nem megfelelő típusú!');
        $this->assertTrue(collect(Schema::getColumns('products'))->firstWhere('name', 'deleted_at')['nullable'], 'A products tábla deleted_at mezője nem opcionális!');
    }

    public function test_product_seeder_correct(): void
    {
        $this->seed(ProductSeeder::class);
        $this->assertDatabaseCount('products', 11);
    }

    public function test_product_model_exists(): void 
    {
        $this->assertTrue(class_exists(Product::class), 'Nem létezik a Product modell!');
    }

    public function test_product_model_traits_correct(): void 
    {
        $this->assertContains(SoftDeletes::class, class_uses(Product::class), 'A SoftDeletes trait nem található a Product modellen!');
    }

    public function test_product_model_full_price_attribute_correct(): void {
        $data = [ 'price' => 1, 'vat' => 0.50, ];
        $product = new Product();
        $product->price = $data['price'];
        $product->vat = $data['vat'];
        $this->assertEquals($product->fullPrice, round($data['price'] + ($data['price'] * $data['vat'])), 'A Product modell fullPrice attribútuma nem megfelelő!');
    }

    public function test_making_a_get_request_to_products_index(): void {
        $this->seed();
        $response = $this->getJson('/api/products');
        $response->assertStatus(200)
            ->assertJson(
                fn (AssertableJson $json) =>
                    $json->has('data', 11)
                        ->has('data.0', fn (AssertableJson $json) =>
                            $json->where('id', 1)
                                ->where('name', 'Kenyér')
                                ->where('price', 899)
                                ->where('unit', 'kg')
                                ->where('image', 'http://backend.vm1.test/images/products/bread.png')
                                ->missing('vat')
                                ->missing('created_at')
                                ->missing('updated_at')
                                ->missing('deleted_at')
                        )
            );
    }

    public function test_making_a_get_request_with_query_string_to_products_index(): void {
        $this->seed();
        $response = $this->getJson('/api/products?name=zsemle');
        $response->assertStatus(200)
            ->assertJson(
                fn (AssertableJson $json) =>
                    $json->has('data', 2)
                        ->has('data.0', fn (AssertableJson $json) =>
                            $json->where('id', 5)
                                ->where('name', 'Vizes zsemle')
                                ->where('price', 89)
                                ->where('unit', 'piece')
                                ->where('image', 'http://backend.vm1.test/images/products/hard-dough-roll.png')
                                ->missing('vat')
                                ->missing('created_at')
                                ->missing('updated_at')
                                ->missing('deleted_at')
                        )
            );
    }

    public function test_making_a_get_request_to_products_show(): void {
        $this->seed();
        $response = $this->getJson('/api/products/1');
        $response->assertStatus(200)
            ->assertJson(
                fn (AssertableJson $json) =>
                    $json->has('data', fn (AssertableJson $json) =>
                            $json->where('id', 1)
                                ->where('name', 'Kenyér')
                                ->where('price', 899)
                                ->where('unit', 'kg')
                                ->where('image', 'http://backend.vm1.test/images/products/bread.png')
                                ->missing('vat')
                                ->missing('created_at')
                                ->missing('updated_at')
                                ->missing('deleted_at')
                        )
            );
    }

    public function test_making_a_get_request_for_non_existent_model_to_products_show(): void {
        $response = $this->getJson('/api/products/1');
        $response->assertStatus(404);
    }
}
