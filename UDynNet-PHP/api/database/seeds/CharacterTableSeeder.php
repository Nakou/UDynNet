<?php

use Illuminate\Database\Seeder;
use Illuminate\Database\Eloquent\Model;
use App\Models\Character;

class CharacterTableSeeder extends Seeder{
	public function run(){
		Character::create([
			'user_id'=> 1,
			'character_name' => 'Super Women',
			'level' => 1
			]);
		Character::create([
			'user_id'=> 2,
			'character_name' => 'Super Man',
			'level' => 1
			]);
	}
}