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

$app->get('/{username}', 'UserController@showUser');