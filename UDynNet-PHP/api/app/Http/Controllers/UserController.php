<?php

namespace App\Http\Controllers;

//use App\User;
use Illuminate\Http\Request;

class UserController extends Controller
{
	public function showUser(Request $request, $id){
		return \App\Models\User::find($id);
	}

  public function login(Request $request){
    $login = $request->input('login');
    $password = $request->input('password');

    $user = \App\Models\User::where('username', $login)
      ->where('password', $password)
      ->first();
  
    if($user != null){
      $user->token = "token!!!!";
      $user->save();
      return $user->token;
    }
    return "{'false'}";  
  }

  public function update(Request $request){
    $token = $request->input('token');
    $user = \App\Models\User::where('token', $token)->first();
    return $user;
  }

}
