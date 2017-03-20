<?php 

$app->get('/user/{token}', function ($id) {
    return App\Models\User::find($id);
});

