<?php

namespace App\Http\Controllers;

use App\Http\Requests\StoreOrganizationRequest;
use App\Http\Requests\UpdateOrganizationRequest;
use App\Http\Resources\OrganizationResource;
use App\Models\Organization;

class OrganizationController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        return OrganizationResource::collection(Organization::with('characters')->get());
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(StoreOrganizationRequest $request)
    {
        $data = $request->validated();
        $organization = Organization::create($data);
        return new OrganizationResource($organization->load('characters'));
    }

    /**
     * Display the specified resource.
     */
    public function show(Organization $organization)
    {
        return new OrganizationResource($organization->load('characters'));
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(UpdateOrganizationRequest $request, Organization $organization)
    {
        $data = $request->validated();
        $organization->update($data);
        return new OrganizationResource($organization->load('characters'));
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(Organization $organization)
    {
        return $organization->delete() ? response()->noContent() : abort(500);
    }
}
