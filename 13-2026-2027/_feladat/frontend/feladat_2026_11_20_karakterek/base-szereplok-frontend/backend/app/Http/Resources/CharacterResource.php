<?php

namespace App\Http\Resources;

use Illuminate\Http\Request;
use Illuminate\Http\Resources\Json\JsonResource;

class CharacterResource extends JsonResource
{
    /**
     * Transform the resource into an array.
     *
     * @return array<string, mixed>
     */
    public function toArray(Request $request): array
    {
        return [
            'id' => $this->id,
            'name' => $this->name,
            'type' => $this->type,
            'occupation' => $this->occupation,
            'description' => $this->description,
            'image' => asset('images/' . $this->image),
            'organization' => new OrganizationResource($this->whenLoaded('organization')),
        ];
    }
}
