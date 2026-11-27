<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;

class Transaction extends Model
{
    /** @use HasFactory<\Database\Factories\TransactionFactory> */
    use HasFactory;

    public function senderAccount() : BelongsTo
    {
        return $this->belongsTo(Account::class);
    }

    public function recipientAccount()
    {
        return $this->belongsTo(Account::class);
    }
}
