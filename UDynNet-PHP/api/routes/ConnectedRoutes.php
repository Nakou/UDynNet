<?php 

$app->post('/login', 'UserController@login');
$app->post('/register', 'UserController@register');

$app->post('/updateinfos', ['middleware' => 'auth', 'uses' => 'UserController@update']);