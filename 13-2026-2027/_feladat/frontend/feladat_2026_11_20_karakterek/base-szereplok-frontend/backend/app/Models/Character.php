<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Attributes\Fillable;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;

#[Fillable('name','type','occupation','description','image','organization_id')]
class Character extends Model
{
    public function organization(): BelongsTo {
        return $this->belongsTo(Organization::class);
    }
}
