<h1 align="center">UDynNet Server System - Nakou (c) 2017</h1>

<p align="center"><b>Plateform fully-automated which can handle a pseudo-dedicated server for Unity3D multiplayer games.</b></p>
<p align="center"><a href="https://raw.githubusercontent.com/Nakou/UDynNet/master/LICENSE"><img src="https://img.shields.io/badge/license-MIT-blue.svg"/></a></p>

## Table of Contents

* [Concept](#concept)
  * [Why](#why)
  * [The Projet](#the-projet)
  * [What we use](#what-we-use)
  * [Why it's partialy problematic](#why-it-s-partialy-problematic)
  * [The Idea](#the-idea)
  * [How this work](#how-this-work)
  * [Why](#why)
* [Installation](#installation)
* [Usage](#usage)
* [Commands](#commands)
* [Contributing](#contributing)
* [Author](#author)
* [License](#License)
* [Thanks](#thanks)

## Concept

The Projet :
The goal is to make a plateform fully-automated which can handle a pseudo-dedicated server for Unity3D multiplayer games.

### Why
Today you cannot create a dedicated server with the UNet standard unity networking system. You depends on direct connection between users or using the Unity3D(c) Matchmaking system sell by Unity3D, or you have to use the old legacy networking lib in Unity (which date from Unity3 and it's not what we can call a "cutting edge" technilogy).

### What we use
The goal is to dynamicly use the current networking player-to-hostplayer system. It's a cool system to use because it's easy to understand, standard based on the Unity3D system, efficient and easily debbuggable.
To see this system in action, just try out the NetworkManager et NetworkGUI currently by default in Unity Project, to see how easy it's to use.

### Why it's partialy problematic

The current system is good, but has one big default : the hostplayer is the server. That mean, even if the player dont understand that, it's in full control on what's going on in the game. Even with the matchmaking from Unity3D, it's juste a cool thing to avoid people to exchange IP addresses. For a hacker, it's heaven on computer to have the server controlled on a machine.

### The Idea

The fundamental idea is to have a player, server-sided, headless, on a server controled by you, and none of the player in the game. For Unity, it's like having an invisible player who launched and hosted the game.
Everytime a player wants to play, register into a matchmaking system, the system will create for him a server "stand-alone", somewhere, and the player will connect to it.

### How this work
**IMPORTANT NOTE:** All of this is just concepts and stuff, nothing is fixed for now, and this project is more an experimentation than a real think that would work someday

The system's composed by distincts elements which work together :

* The Game Client : The Unity3D game distributed to the player.
* UDynNet-PHP : This sever will simply handle the player connection and get some infos like level and stuff.
* UDynNet-Node : This server will check if enough player are available to legitimate launching a server.
* UDynNet-Unity : This is the Unity3D Client handle by the server, which will be a headless client with only the launch "as a server" will be available.

## Installation
[Not yet]
## Usage
[Not yet]
## Commands
[Not yet]
## Contributing
[Not yet]

## Author

Nakou : I'm just a poor Computer Engineer who do shit in Java at work, but develop a lot of stuff with Unity since 2011 and got bored by Java and want to <b>DREAM BIGGER</b>.

## License
```
The MIT License (MIT)

Copyright (c) 2017 Nakou

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
```

## Thanks