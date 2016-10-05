# Carty

Warning following text is WIP.

Carty (English transcription for Czech word for Cards) is a game engine for Trading Card Games (TCG) written in Unity. Disclaimer right from start, the engine is heavily inspired by Hearthstone and following description might be using Hearthstone terminology.

## Vision of the engine

__Jumping in and creating new cards is very easy!__

Since this engine has a background in Ludum Dare, a 48 hours-long game development jam, one of the core ideas behind it is to make creating the content for it as easy as possible. This is achieved through extensive use of defaults. Think: how cards move around, number of cards in deck or the cards' visual composition. The defaults are mostly Hearthstone inspired. It is important to note that while there is an emphasis on these defaults, the Carty engine strives for deep customizability at the same time.

Second key idea behind this vision is encapsulation of core game logic and creating a high-quality API on top of it. Developers don't have to concern themselves with inner-workings of the engine (unless they want to) and can implement their ideas in a clear and transparent language of API. The API provides:

* Accessors for players decks, hands and boards
* Deal damage, heal, modify stats of minions
* Other means of cards manipulation such draw, discard, discover etc.

__Three pillars: Visuals - Game logic - Cards__  

The engine attempts to separate these three pillars as much as possible. 

The reason for separating Visuals from Game logic was already hinted at in the previous section with the "defaults" and customizability. While the game logic is relatively unchanging, visuals are the easiest way to customize the engine. Therefore game logic is a separate project (and dll), while visuals are part of the Unity project and come with defaults.

Separation of the Game logic and Cards is the already described API approach. It makes lives of the users of the engine easier and plays along nicely with seperate dll for game logic.

## Project structure

TODO

## Getting started

TODO

## History

TODO