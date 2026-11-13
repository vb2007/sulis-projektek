<?php

namespace Tests\Feature;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Foundation\Testing\RefreshDatabase;
use Illuminate\Foundation\Testing\WithFaker;
use Tests\TestCase;

class ConfigTest extends TestCase
{
    public function test_images_link_exists(): void
    {
        $path = public_path('images');
        $this->assertFileExists($path, 'Nem létezik az images link!');
        $this->assertTrue(is_link($path), 'Nem létezik az images link!');
    }

    public function test_eloquent_strict_mode(): void {
        $this->assertTrue(Model::preventsLazyLoading(), 'A lazy loading tiltása nincs bekapcsolva!');
        $this->assertTrue(Model::preventsSilentlyDiscardingAttributes(), 'A nem engedélyezett attribútumok eldobásának tiltása nincs bekapcsolva!');
        $this->assertTrue(Model::preventsAccessingMissingAttributes(), 'A hiányzó attribútumok elérésének tiltása nincs bekapcsolva!');
    }
}
