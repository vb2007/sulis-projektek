<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class AccountSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        DB::table('accounts')->insert([
            [
                'type' => 'checking',
                'name' => 'Primary Checking',
                'balance' => 1450.75,
                'client_id' => 1,
            ],
            [
                'type' => 'family savings',
                'name' => 'Joint Savings',
                'balance' => 28400.00,
                'client_id' => 1,
            ],
            [
                'type' => 'checking',
                'name' => 'Everyday Account',
                'balance' => 980.20,
                'client_id' => 2,
            ],
            [
                'type' => 'traditional savings',
                'name' => 'Emergency Fund',
                'balance' => 19250.50,
                'client_id' => 2,
            ],
            [
                'type' => 'checking',
                'name' => null,
                'balance' => 4210.00,
                'client_id' => 3,
            ],
            [
                'type' => 'traditional savings',
                'name' => 'Retirement Savings',
                'balance' => 35600.00,
                'client_id' => 3,
            ],
            [
                'type' => 'checking',
                'name' => 'Personal Checking',
                'balance' => 12450.80,
                'client_id' => 4,
            ],
            [
                'type' => 'checking',
                'name' => 'Main Checking',
                'balance' => 89300.00,
                'client_id' => 5,
            ],
            [
                'type' => 'traditional savings',
                'name' => 'Long-Term Savings',
                'balance' => 145000.00,
                'client_id' => 5,
            ],
            [
                'type' => 'checking',
                'name' => 'Business Checking',
                'balance' => 64200.40,
                'client_id' => 6,
            ],
            [
                'type' => 'family savings',
                'name' => 'Family Reserve',
                'balance' => 210000.00,
                'client_id' => 6,
            ],
            [
                'type' => 'checking',
                'name' => 'Checking Account',
                'balance' => 3150.00,
                'client_id' => 7,
            ],
            [
                'type' => 'checking',
                'name' => null,
                'balance' => 2890.65,
                'client_id' => 8,
            ],
            [
                'type' => 'family savings',
                'name' => 'Home Downpayment',
                'balance' => 14800.00,
                'client_id' => 8,
            ],
            [
                'type' => 'checking',
                'name' => 'Daily Expenses',
                'balance' => 5430.10,
                'client_id' => 9,
            ],
            [
                'type' => 'traditional savings',
                'name' => 'Savings Account',
                'balance' => 18900.00,
                'client_id' => 9,
            ],
            [
                'type' => 'checking',
                'name' => 'Standard Checking',
                'balance' => 7640.90,
                'client_id' => 10,
            ],
            [
                'type' => 'checking',
                'name' => 'Operating Account',
                'balance' => 22100.00,
                'client_id' => 11,
            ],
            [
                'type' => 'traditional savings',
                'name' => null,
                'balance' => 54000.00,
                'client_id' => 11,
            ],
            [
                'type' => 'checking',
                'name' => 'Direct Deposit',
                'balance' => 41800.25,
                'client_id' => 12,
            ],
            [
                'type' => 'checking',
                'name' => 'Basic Checking',
                'balance' => 640.00,
                'client_id' => 13,
            ],
            [
                'type' => 'checking',
                'name' => 'Bills & Rent',
                'balance' => 9320.50,
                'client_id' => 14,
            ],
            [
                'type' => 'family savings',
                'name' => 'College Fund',
                'balance' => 27500.00,
                'client_id' => 14,
            ],
            [
                'type' => 'checking',
                'name' => 'Primary Account',
                'balance' => 78900.00,
                'client_id' => 15,
            ],
            [
                'type' => 'traditional savings',
                'name' => 'High-Yield Savings',
                'balance' => 320000.00,
                'client_id' => 15,
            ],
        ]);
    }
}
