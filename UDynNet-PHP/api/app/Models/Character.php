<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Character extends Model{

	protected $table = 'character';

	protected $fillable = [
		'user_id',
		'character_name',
		'level',
		'vectorPosition',
		'vectorRotation'
		];

	public static function getCharactersByUserId($id){
		$characterList = app('db')->table('character')
		->where('user_id', $id)
		->get();
		return $characterList;
	}

	
}