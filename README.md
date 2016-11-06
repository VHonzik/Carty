# Carty

Warning the following text is WIP.

Carty [[kʌrtɪ]](https://en.wikipedia.org/wiki/Help:IPA_for_English) is a game engine for Trading Card Games (TCG) written in Unity. The word origin is an approximate English transcription of Czech word for cards.

*Disclaimer right from the start, the engine is inspired by Hearthstone and following description might be using Hearthstone terminology.*

## Vision of the engine

__I can jump in and create new cards very easily!__

Since this engine has a background in Ludum Dare, a 48 hours-long game development jam, one of the core ideas behind it is to make creating the content for it as easy as possible. This is achieved through extensive use of "defaults". Think, how cards move around, number of cards in deck or the cards' visual composition. The defaults are mostly Hearthstone inspired.

Second key idea behind this vision is encapsulation of core game logic and creating a high-quality API on top of it. Developers don't have to concern themselves with inner-workings of the engine (unless they want to) and can implement their ideas in a clear and transparent language of API. The API provides:

* Accessors for players' decks, hands and boards
* Deal damage, heal, modify stats of minions
* Other means of cards manipulation such draw, discard, discover etc.

__I can costumize most aspects of the engine.__

On the other hand, Carty tries to keep in mind that one shouldn't sacrifice customizability to gain accessibility.

The choice of word "defaults" in the previous section is not accidental. They are decoupled from the code which is using them and are accessed through interface. This gives you ability to simply swap-in your custom implementation of them.

In other words, you start with Hearthstone-feel engine but can end up with any other TCG out there.

__Three pillars: Visuals - Game logic - Cards__  

The engine attempts to separate these three pillars as much as possible. 

The reason for separating Visuals from Game logic was already hinted at in the previous sections with the "defaults" and customizability. While the game logic is relatively unchanging, visuals are the easiest way to customize the engine. Therefore game logic and visuals are a separate projects (and dlls).

Separation of the Game logic and Cards is the already described API approach. It makes lives of the users of the engine easier and plays along nicely with seperate dll for game logic.

## Project structure

TODO

## Getting started

TODO

## History

Late August 2016 - Precursor of Carty - TCG Game - is created for Ludum Dare 36 ([link]{http://ludumdare.com/compo/ludum-dare-36/?action=preview&uid=36014}). 
September 2016 - December 2016 - First iteraction of Carty is in development. While functionaly it is almost identical to the precursor, heavy refactoring is happening.