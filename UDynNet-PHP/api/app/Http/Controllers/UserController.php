<?php

namespace App\Http\Controllers;

use App\User;

class UserController extends Controller
{
	public function showUser(Request $request, $id){
		return App\Models\User::find($id);
	}

}
