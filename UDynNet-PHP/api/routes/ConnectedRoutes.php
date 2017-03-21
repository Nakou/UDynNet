<?php 

$app->put('user/{id}', 'UserController@showUser');

$app->get('/user/create/{login}/{password}', function ($login, $password) {
    return App\Models\User::create($login, $password);
});

$app->get('/user/get/{token}/{id}', function ($id) {
    return App\Models\User::find($id);
});

$app->get('/user/set/{token}/{field}/{content}', function ($id) {
    return App\Models\User::find($id);
});

$app->get('/user/{token}', function ($id) {
    return App\Models\User::find($id);
});