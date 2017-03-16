<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Character extends Model{

	protected $table = 'character';

	protected $fillable = [
		'user_id',
		'character_name',
		'level'
		];
}