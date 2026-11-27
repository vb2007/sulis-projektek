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
        Schema::create('transactions', function (Blueprint $table) {
            $table->id();
            $table->dateTime("transaction_at");
            $table->string("note", 255)->nullable();
            $table->decimal("amount");
            $table->foreignId("sender_account_id")->nullable()->constrained("accounts", "id");
            $table->foreignId("recipient_account_id")->nullable()->constrained("accounts", "id");
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('transactions');
    }
};
