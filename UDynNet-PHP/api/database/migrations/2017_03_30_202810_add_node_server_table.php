<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class AddNodeServerTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('nodeserver', function (Blueprint $table) {
            $table->bigIncrements('id');
            $table->string('server_ip');
            $table->string('server_name');
            $table->string('token');
            $table->timestamps();

            $table->index('token');            
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        //
    }
}
