<?php

use Illuminate\Http\Request;
use App\Http\Controllers\Controller;

class CarController extends Controller {
    public function index() {
        return "autók a controllerben";
    }
}