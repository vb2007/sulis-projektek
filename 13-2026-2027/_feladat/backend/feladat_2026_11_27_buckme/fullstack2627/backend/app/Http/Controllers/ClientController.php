<?php

namespace App\Http\Controllers;

use App\Http\Requests\StoreClientRequest;
use App\Http\Requests\UpdateClientRequest;
use App\Models\Client;

class ClientController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        return Client::with('accounts')->get();
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(StoreClientRequest $request)
    {
        return Client::create($request->validated())->load('accounts');
    }

    /**
     * Display the specified resource.
     */
    public function show(Client $client)
    {
        return $client->load('accounts');
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(UpdateClientRequest $request, Client $client)
    {
        $client->update($request->validated());

        return $client->load('accounts');
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(Client $client)
    {
        try {
            $client->delete();
        } catch (\Throwable $e) {
            return response()->json(['message' => $e->getMessage()], 409);
        }

        return response()->noContent();
    }
}
