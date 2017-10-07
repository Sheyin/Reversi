using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    class Reversi
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is a game of Reversi (Othello).");

            // encapsulate in while loop
            GameBoard game = new GameBoard();
            game.print();

            Tuple<int, int> move;
            int row, col;
            char confirm = 'N';

            do
            {
                move = getInput();
                row = move.Item1;
                col = move.Item2;
                Console.WriteLine("Location selected: Row " + row + ", Column " + col);
                Console.Write("Is this correct? ");
                confirm = Console.ReadKey().KeyChar;
                Console.Write('\n');
            } while (confirm != 'Y' && confirm != 'y');

            bool valid = game.isLegalMove('b', row-1, col-1);
            if (!valid) {
                Console.WriteLine("Error - an invalid move was made!");
            }
            else
            {
                Console.WriteLine("A valid move was made.");
                // modify board etc
            }

            


            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static Tuple<int, int> getInput()
        {
            Console.Write('\n');
            Console.Write("For the space you want to move to, enter the row: ");
            string positionRow = Console.ReadLine();

            // Check if number
            int row, col;
            while (!int.TryParse(positionRow, out row) || (row <= 0) || (row >= 8))
            {
                // error and repeat input here
                Console.WriteLine("Error: This is an invalid row.  Please enter a new row: ");
                positionRow = Console.ReadLine();
            }

            Console.Write("Please enter a column: ");
            string positionCol = Console.ReadLine();

            while (!int.TryParse(positionCol, out col) || (col <= 0) || (col >= 8))
            {
                // error and repeat input here
                Console.WriteLine("Error: This is an invalid column.  Please enter a new column: ");
                positionCol = Console.ReadLine();
            }

            return Tuple.Create(row, col);
        }
    }
}
