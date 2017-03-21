<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class User extends Model{

	protected $table = 'users';

	protected $fillable = [
		'email',
		'username',
		'password',
		'last_connection_attempt',
		'remaining_attempts',
		'token'];

	protected $hidden = ['password', 'token'];
}