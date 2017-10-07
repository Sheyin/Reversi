using System;
using System.Collections;

public class GameBoard
{
    // This defines the game board object
    const int ROWS = 8;
    const int COLS = 8;
    char[,] board;

    // Is a constructor needed?
    public GameBoard()
    {
        board = new char[ROWS, COLS];

        // initialize board to have all blank spaces
        for (int i = 0; i < COLS; i++)
        {
            for (int j = 0; j < ROWS; j++)
            {
                board[i, j] = ' ';
            }
        }

        // Add the starting pieces in the center
        board[3, 3] = 'w';
        board[3, 4] = 'b';
        board[4, 3] = 'b';
        board[4, 4] = 'w';
    }

    // Display the game board in the console.
	public void print()
	{
        // print column numbers first
        Console.Write("  ");
        for (int k = 1; k <= COLS; k++)
        {
            Console.Write(" " + k + " ");
        }
        Console.Write('\n');

        // print the rest of the board data
        for (int i = 0; i < COLS; i++)
        {
            Console.Write(i + 1 + " ");
            for(int j = 0; j < ROWS; j++)
            {
                Console.Write("[" + board[i, j] + "]");
            }
            Console.Write('\n');
        }
     
	}

    // Updates board temporarily and displays the to-be move.
    public void updateBoardTemp(char color, int row, int col)
    {
        char[,] boardTemp = (char [,]) board.Clone();
        boardTemp[row, col] = 'X';

        // should REALLY redo the print function to allow this and recycle code
        // But I'm lazy for now

        // print column numbers first
        Console.Write("  ");
        for (int k = 1; k <= COLS; k++)
        {
            Console.Write(" " + k + " ");
        }
        Console.Write('\n');

        // print the rest of the board data
        for (int i = 0; i < COLS; i++)
        {
            Console.Write(i + 1 + " ");
            for (int j = 0; j < ROWS; j++)
            {
                Console.Write("[" + boardTemp[i, j] + "]");
            }
            Console.Write('\n');
        }
    }

    // Returns true or false depending on whether the move was actually made.
    // May want to move error message to the function calling the move.
    public bool placePiece(char color, int row, int col)
    {
        // Check if it is a legal move (an opposing piece must be taken)
        if (isLegalMove(color, row, col))
        {
            board[row, col] = color;
            return true;
        }

        else
        {
            Console.WriteLine("Error: This is an illegal move.  Please pick a new location.");
            return false;
        }
    }

    public bool isLegalMove(char newPiece, int row, int col)
    {
        // Check if position is blank / unclaimed
        if (this.board[row, col] != ' ') {
            Console.WriteLine("Error, this position is already occupied by [" + board[row, col] + "].");
            return false;
        }

        // Check if position has an opposing piece adjacent to it
        string[] directions = { "topLeft", "topCenter", "topRight", "rightCenter", "bottomRight", "bottomCenter", "bottomLeft", "leftCenter" };

        bool matchFound = false;

        for (int i = 0; i < 8; i++)
        {
            if (checkDirection(newPiece, row, col, directions[i]))
            {
                return true;
            }
        }

        // No adjacent pieces that can be flipped in any direction, so it is illegal.
        return false;  
    }

    // Makes an arrayList of pieces starting from the one next to origin and continuing in a given direction (not including origin)
    // newRow, newCol: Starting point for array[0]
    // rowModifier, colModifier: How much row / col should be increased or decreased until hits border
    ArrayList makeArrayOfLine(int newRow, int newCol, int rowModifier, int colModifier)
    {
        ArrayList array = new ArrayList();

        // if the first adjacent spot in the indicated direction is a space or border, the array is empty.
        newRow += rowModifier;
        newCol += colModifier;
        if (board[newRow, newCol] == ' ' || newRow < 0 || newRow >= ROWS || newCol < 0 || newCol >= COLS)
        {
            return array;
        }

        else
        {
            array.Add(board[newRow, newCol]);
            do
            {
                newRow += rowModifier;
                newCol += colModifier;
                array.Add(board[newRow, newCol]);
            } while (newRow > 0 && newCol > 0 && newRow < ROWS-1 && newCol < COLS-1);

            return array;
        }
    }

    bool checkDirection(char newPiece, int newRow, int newCol, string direction)
    {
        ArrayList lineArray;
        switch(direction)
        {
            case "topLeft":
                lineArray = makeArrayOfLine(newRow, newCol, -1, -1);
                return checkArrayForColorLine(newPiece, lineArray);
                break;
            case "topCenter":
                lineArray = makeArrayOfLine(newRow, newCol, -1, 0);
                return checkArrayForColorLine(newPiece, lineArray);
                break;
            case "topRight":
                lineArray = makeArrayOfLine(newRow, newCol, -1, 1);
                return checkArrayForColorLine(newPiece, lineArray);
                break;
            case "rightCenter":
                lineArray = makeArrayOfLine(newRow, newCol, 0, 1);
                return checkArrayForColorLine(newPiece, lineArray);
                break;
            case "bottomRight":
                lineArray = makeArrayOfLine(newRow, newCol, 1, 1);
                return checkArrayForColorLine(newPiece, lineArray);
                break;
            case "bottomCenter":
                lineArray = makeArrayOfLine(newRow, newCol, 1, 0);
                return checkArrayForColorLine(newPiece, lineArray);
                break;
            case "bottomLeft":
                lineArray = makeArrayOfLine(newRow, newCol, 1, -1);
                return checkArrayForColorLine(newPiece, lineArray);
                break;
            case "leftCenter":
                lineArray = makeArrayOfLine(newRow, newCol, 0, -1);
                return checkArrayForColorLine(newPiece, lineArray);
                break;
            default:
                Console.WriteLine("Error: unidentified direction.");
                return false;
                break;
        }
    }

    bool checkArrayForColorLine(char terminatingColor, ArrayList array)
    {
        int numOpposingColor = 0;
        for (int i = 0; i < array.Count; i++)
        {
            if (array[i].Equals(terminatingColor))
            {
                if (numOpposingColor == 0)
                {
                    return false;
                }

                else
                {
                    return true;
                }
            }

            else if (array[i].Equals(' '))
            {
                return false;
            }

            else
            {
                numOpposingColor++;
            }
        }
        return false;
    }


}
