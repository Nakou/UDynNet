<?php

/*
*
* Entry Point (version, /, login)
*
*/

$app->get('/', function () use ($app) {
    $version = env('API_VERSION', 'MISSING');
    return "UDynNet Web API \"Snail\" Version ".$version;
});

$app->get('/login/{login}/{pwd}', function ($login, $pwd) {
	$result = DB::table('users')
	->where('username', $login)
	->where('password', $pwd)
	->get();
	
	if(count($result) == 1){
		return "{'true'}";
	}
	return "{'false'}";
});
