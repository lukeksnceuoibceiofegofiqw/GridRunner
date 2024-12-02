
Welcome to the gridRunner Repository.

This project implements a domain specific interpreted programming language, 
And a gui editor to play with it.


This project consists of three parts.
A main project that handles the gui, 
A class library that implements the programming language and the game that it runs in.
And a test suite for the class library.

MSO_3 is the main project.
The entry point can be found under Program.
The FormsApp holds is the root of the gui elements.
The AssetRepository holds all images
The mediator is a facade for all the functionality of the program that gui elements can easily communicate with.
All the complex functionality is handled by the file manager or the GridRunnerProgram class library. 

GridrunnerProgram
GridRunnerProgram is subdivided in a game state, a program, and the controlls
State contains the game state
Commands form a recursive structure that can contain conditionals.
The run functions from a command can return a run error.
the gridrunner class implements all public functions for controlling the program. 
The state is public to allow users to make their own drawing code. 
The state contains minimal code, 
the only exception is the mode class that is stored in state but is called from gridRunnerProgram.
the parsers are implemented as static classes and used by the gridrunnerprogram class

possible commands are 
- Move <num>
- Turn <num>
- Repeat <num>
- RepeatUntil <Condition>
- If <Condition>

Conditions are
- SpaceAhead
- WallAhead 
- GridEdge	(on one a square next to the edge)
- OnTarget 

There are two types of excersizes
In the shape excersize one needs to walk on all squares and end on the starting position.
In the Path excersize the guy needs to manuever to the goal.

////Example program --Perfect maze solver 

RepeatUntil SpaceAhead
	Turn right
Move 1
RepeatUntil OnTarget
	Turn right
	RepeatUntil SpaceAhead
		Turn left
	Move 1

////Example world


ooooooo
++++++o
x++o++o
o+ooo+o
ooo+ooo


