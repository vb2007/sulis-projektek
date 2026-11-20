<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Attributes\Fillable;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\HasMany;

#[Fillable('name','type','area')]
class Organization extends Model
{
    public function characters(): HasMany {
        return $this->hasMany(Character::class);
    }
}
