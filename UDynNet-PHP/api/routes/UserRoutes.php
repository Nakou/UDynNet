<?php

$app->get('/getUser/{id}', function ($id) {
    return App\Models\User::find($id);
});

$app->get('/getCharacterFromUser/{idUser}', function ($idUser) {
	$user = App\Models\User::find($idUser);

	$characterList = DB::table('character')
		->where('user_id', $idUser)
		->get(); // => put that into the User Model class

    return $characterList;
});