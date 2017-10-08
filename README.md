A Reversi (Othello) game in C# I'm writing up for practice.  Bear with me, this is my first time using C#!

# Rules
Player leads with a black piece.  (Not sure if it will be 1-player or 2-player yet.)  Each turn, a player must "flip" an opposing piece by placing a piece adjacent to an opposing-color piece(s), which is eventually terminated by another piece of that player's color.  For example: Black - White - Black would be a legal move, horizontally, diagonally, or vertically; the number of white pieces in between can also be as many as possible.  The game ends when there are no longer any legal moves, and whoever has the most pieces wins.

# Current State
It runs once, lets you place a piece and checks whether it is a legal move.
