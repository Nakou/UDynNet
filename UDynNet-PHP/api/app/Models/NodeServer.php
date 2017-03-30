<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class NodeServer extends Model{

	protected $table = 'nodeserver';

	protected $fillable = [
		'server_ip',
		'server_name',
		'token'
		];

	public static function registerNewServer($serverAddress, $serverName, $token){
		$newServer = new NodeServer;
		$newServer->server_ip = $serverAddress;
		$newServer->server_name = $serverName;
		$newServer->token = $token;
		$newServer->save();
		
		return $characterList;
	}

	
}