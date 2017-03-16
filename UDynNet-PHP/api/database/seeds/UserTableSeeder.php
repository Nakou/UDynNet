<?php

use Illuminate\Database\Seeder;
use Illuminate\Database\Eloquent\Model;
use App\Models\User;

class UserTableSeeder extends Seeder{
	public function run(){
		User::create([
			'email' => 'test@test.com',
			'username' => 'test',
			'password' => '123test',
			'last_connection_attempt' => time(),
			'remaining_attempts' => 3
			]);
		User::create([
			'email' => 'test2@test.com',
			'username' => 'test2',
			'password' => '123456test',
			'last_connection_attempt' => time(),
			'remaining_attempts' => 3
			]);
	}
}