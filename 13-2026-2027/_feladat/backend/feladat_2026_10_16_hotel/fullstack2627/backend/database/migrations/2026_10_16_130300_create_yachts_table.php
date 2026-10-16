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
        Schema::create('yachts', function (Blueprint $table) {
            $table->id();
            $table->foreignId("guest_id")->constrained("guests");
            $table->string("manufacturer", 30);
            $table->string("model", 30);
            $table->boolean("sailing");
            $table->year("year");
            $table->string("color", 30);
            $table->integer("price");
            $table->dateTime("from");
            $table->dateTime("to")->nullable();
            $table->string("name");
            $table->softDeletes();
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('yachts');
    }
};
