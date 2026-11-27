<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class TransactionSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        DB::table('transactions')->insert([
            [
                'transaction_at' => '2026-10-02 09:15:00',
                'note' => 'Monthly savings transfer',
                'amount' => 500.00,
                'sender_account_id' => 1,
                'recipient_account_id' => 2,
            ],
            [
                'transaction_at' => '2026-10-04 14:22:10',
                'note' => 'Split dinner bill',
                'amount' => 45.50,
                'sender_account_id' => 3,
                'recipient_account_id' => 1,
            ],
            [
                'transaction_at' => '2026-10-05 18:05:45',
                'note' => 'Emergency fund top-up',
                'amount' => 1200.00,
                'sender_account_id' => 3,
                'recipient_account_id' => 4,
            ],
            [
                'transaction_at' => '2026-10-07 11:30:00',
                'note' => null,
                'amount' => 250.00,
                'sender_account_id' => 5,
                'recipient_account_id' => 7,
            ],
            [
                'transaction_at' => '2026-10-09 16:40:12',
                'note' => 'Consulting invoice #104',
                'amount' => 3400.00,
                'sender_account_id' => 10,
                'recipient_account_id' => 8,
            ],
            [
                'transaction_at' => '2026-10-10 08:50:00',
                'note' => 'Transfer to long-term savings',
                'amount' => 5000.00,
                'sender_account_id' => 8,
                'recipient_account_id' => 9,
            ],
            [
                'transaction_at' => '2026-10-12 20:15:33',
                'note' => 'Concert tickets',
                'amount' => 180.00,
                'sender_account_id' => 12,
                'recipient_account_id' => 17,
            ],
            [
                'transaction_at' => '2026-10-14 13:10:05',
                'note' => 'Rent share October',
                'amount' => 950.00,
                'sender_account_id' => 13,
                'recipient_account_id' => 22,
            ],
            [
                'transaction_at' => '2026-10-15 10:00:00',
                'note' => 'House fund deposit',
                'amount' => 800.00,
                'sender_account_id' => 13,
                'recipient_account_id' => 14,
            ],
            [
                'transaction_at' => '2026-10-18 15:45:20',
                'note' => 'Equipment rental',
                'amount' => 420.75,
                'sender_account_id' => 15,
                'recipient_account_id' => 18,
            ],
            [
                'transaction_at' => '2026-10-20 09:05:11',
                'note' => null,
                'amount' => 1500.00,
                'sender_account_id' => 18,
                'recipient_account_id' => 19,
            ],
            [
                'transaction_at' => '2026-10-22 17:30:40',
                'note' => 'Logistics service payment',
                'amount' => 6250.00,
                'sender_account_id' => 20,
                'recipient_account_id' => 24,
            ],
            [
                'transaction_at' => '2026-10-25 12:18:00',
                'note' => 'Family reserve allocation',
                'amount' => 10000.00,
                'sender_account_id' => 10,
                'recipient_account_id' => 11,
            ],
            [
                'transaction_at' => '2026-10-27 19:22:50',
                'note' => 'Car repair reimbursement',
                'amount' => 310.00,
                'sender_account_id' => 21,
                'recipient_account_id' => 15,
            ],
            [
                'transaction_at' => '2026-10-30 14:00:00',
                'note' => 'College fund contribution',
                'amount' => 600.00,
                'sender_account_id' => 22,
                'recipient_account_id' => 23,
            ],
            [
                'transaction_at' => '2026-11-02 10:45:15',
                'note' => 'Quarterly savings sweep',
                'amount' => 15000.00,
                'sender_account_id' => 24,
                'recipient_account_id' => 25,
            ],
            [
                'transaction_at' => '2026-11-05 16:12:30',
                'note' => null,
                'amount' => 75.00,
                'sender_account_id' => 17,
                'recipient_account_id' => 1,
            ],
            [
                'transaction_at' => '2026-11-08 09:30:00',
                'note' => 'Pension top-up',
                'amount' => 1100.00,
                'sender_account_id' => 5,
                'recipient_account_id' => 6,
            ],
            [
                'transaction_at' => '2026-11-12 11:55:22',
                'note' => 'Supplier settlement',
                'amount' => 2850.40,
                'sender_account_id' => 24,
                'recipient_account_id' => 20,
            ],
            [
                'transaction_at' => '2026-11-18 18:40:00',
                'note' => 'Weekend trip groceries',
                'amount' => 132.80,
                'sender_account_id' => 1,
                'recipient_account_id' => 3,
            ],
        ]);
    }
}
