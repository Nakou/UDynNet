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
      $user->token = sha1($user->email.microtime().env('SALT_TOKEN', '!$@17!'));
      $user->save();
      return $user->token;
    }
    return "{'false'}";  
  }

  public function update(Request $request){
    $token = $request->header('Magik-Token');
    $user = \App\Models\User::where('token', $token)->first();

    if(!empty($request->input('email'))){
      $email = $request->input('email');
      // Lol this will be ugly. ¯\_(ツ)_/¯
      $retValueEmailChecker = $this->verifyEmail($email);
      if($retValueEmailChecker === true){
        $user->email = $email;
      } else {
        return $retValueEmailChecker;
      }
    }
    
    if(!empty($request->input('password'))){
      $user->password = $request->input('password');
    }

    $user->save();
    return $user;
  }

  /**
  *
  * Check if the email is wellformed.
  *
  */
  private function verifyEmail($email){
    if(!filter_var($email, FILTER_VALIDATE_EMAIL)){
      return $this->errorCode("Bad email format");
    }
    $user = \App\Models\User::where('email', $email)->first();
    if($user != null){
      return $this->errorCode("Email already taken");
    }
    return true;
  }

  
  /**
  *
  * Put error into a correct format for return.
  *
  */
  private function errorCode($errorMsg){
    $error = array('error' => $errorMsg);
    return json_encode($error);
  }

}
