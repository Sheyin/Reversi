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

            // While loop this
            Console.Write("For the space you want to move to, enter the row: ");
            ConsoleKeyInfo positionRow = Console.ReadKey();
            Console.Write('\n');
            Console.WriteLine("You pressed: " + positionRow.KeyChar);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
