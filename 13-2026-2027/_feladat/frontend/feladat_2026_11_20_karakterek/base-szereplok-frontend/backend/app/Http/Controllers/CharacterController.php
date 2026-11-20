<?php

namespace App\Http\Controllers;

use App\Http\Requests\StoreCharacterRequest;
use App\Http\Requests\UpdateCharacterRequest;
use App\Http\Resources\CharacterResource;
use App\Models\Character;

class CharacterController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        return CharacterResource::collection(Character::with('organization')->get());
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(StoreCharacterRequest $request)
    {
        $data = $request->validated();
        $character = Character::create($data);
        return new CharacterResource($character->load('organization'));
    }

    /**
     * Display the specified resource.
     */
    public function show(Character $character)
    {
        return new CharacterResource($character->load('organization'));
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(UpdateCharacterRequest $request, Character $character)
    {
        $data = $request->validated();
        $character->update($data);
        return new CharacterResource($character->load('organization'));
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(Character $character)
    {
        return $character->delete() ? response()->noContent() : abort(500);
    }
}
