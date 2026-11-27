<?php

namespace App\Http\Controllers;

use App\Http\Requests\StoreAccountRequest;
use App\Http\Requests\UpdateAccountRequest;
use App\Models\Account;

class AccountController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        return Account::withDetails()->get();
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(StoreAccountRequest $request)
    {
        return Account::create($request->validated())->loadDetails();
    }

    /**
     * Display the specified resource.
     */
    public function show(Account $account)
    {
        return $account->loadDetails();
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(UpdateAccountRequest $request, Account $account)
    {
        $account->update($request->validated());

        return $account->loadDetails();
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(Account $account)
    {
        try {
            $account->delete();
        } catch (\Throwable $e) {
            return response()->json(['message' => $e->getMessage()], 409);
        }

        return response()->noContent();
    }
}
