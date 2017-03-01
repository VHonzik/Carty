# Carty

Warning the following text is WIP.

Carty [[kʌrtɪ]](https://en.wikipedia.org/wiki/Help:IPA_for_English) is a game engine for Trading Card Games (TCG) written in Unity. The word origin is an approximate English transcription of Czech word for cards.

Currently the project is using Unity 5.5.2f1.

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

The reason for separating Visuals from Game logic was already hinted at in the previous sections with the "defaults" and customizability. While the game logic is relatively unchanging, visuals are the easiest way to customize the engine. Therefore game logic and visuals are under separate namespaces and talk to each other exclusively through GameManager and VisualManager singletons. 

However these two still need to talk to each other so they can't be separated into different assemblies. Instead they form together Carty dll.

Separation of the Game logic and Cards is the already described API approach. It makes lives of the users of the engine easier and plays along nicely with seperate dll for game logic.
User simply imports Carty dll to his Unity project and start writing new cards as MonoBehaviours which implement certain interface(s). Carty dll through "reflection magic" finds these MonoBehaviours and plugs them into the system.

## Project structure

* Carty - C# solution of the Carty library. Its project is imported into the SampleGame Unity project so one usually doesn't need to use this solution. The output dll of building this solution (and project) is copied over to the SampleGame Unity project's asset folders.
* SampleGame - Sample game serving as an example of using Carty library.

## Getting started

### Using Carty engine

Load the SampleGame in Unity and explore how it is used.

### Contributing

You will need [premake](https://premake.github.io/) in order to generate the project. For example if you are using VS 2015 you can change directory to Carty/build/premake and run premake5 vs2015 for VS 2015 solution.

## History

* Late August 2016 - Precursor of Carty - TCG Game - is created for Ludum Dare 36 ([link](http://ludumdare.com/compo/ludum-dare-36/?action=preview&uid=36014)). 
* September 2016 - December 2016 - First iteraction of Carty is in development. While functionaly it is almost identical to the precursor, heavy refactoring is happening.
* January 2017 - Project put on hold while a custom card implementation and evalution is worked on in a different project.