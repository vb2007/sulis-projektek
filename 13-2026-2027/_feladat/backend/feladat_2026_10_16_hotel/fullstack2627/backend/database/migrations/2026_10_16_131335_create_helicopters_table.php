<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::create('helicopters', function (Blueprint $table) {
            $table->id();
            $table->foreignId("guest_id")->constrained("guests");
            $table->string("manufacturer", 30);
            $table->string("model", 30);
            $table->year("year");
            $table->string("color", 30);
            $table->integer("passenger_capacity");
            $table->integer("max_velocity");
            $table->integer("range");
            $table->boolean("twin_engine");
            $table->integer("price");
            $table->dateTime("from");
            $table->dateTime("to")->nullable();
            $table->softDeletes();
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('helicopters');
    }
};
