<?php

namespace App\Http\Requests;

use Illuminate\Contracts\Validation\ValidationRule;
use Illuminate\Foundation\Http\FormRequest;

class StoreCharacterRequest extends FormRequest
{
    /**
     * Determine if the user is authorized to make this request.
     */
    public function authorize(): bool
    {
        return true;
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array<string, ValidationRule|array<mixed>|string>
     */
    public function rules(): array
    {
        return [
            'name' => ['required', 'string', 'max:50'],
            'type' => ['required', 'string', 'in:főszereplő,mellékszereplő'],
            'occupation' => ['required', 'string', 'max:20'],
            'description' => ['required', 'string', 'max:60000'],
            'image' => ['nullable', 'string', 'max:200'],
            'organization_id' => ['required', 'exists:organizations,id'],
        ];
    }
}
