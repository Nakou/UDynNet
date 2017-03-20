<?php

$app->get('/getUser/{id}', function ($id) {
    return App\Models\User::find($id);
});

$app->get('/getCharacterFromUser/{idUser}', function ($idUser) {
	$characterList = App\Models\Character::getCharactersByUserId($idUser);

    return $characterList;
});