using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {

            // This part of the code verify if the board is surely a singleton

            /*
            Singleton_Board plateau = Singleton_Board.getInstance();
            Singleton_Board plateau2 = Singleton_Board.getInstance();
            Console.WriteLine(plateau == plateau2);
            */

            // TO SEE A SIMULATION OF THE MONOPOLY GAME

            Console.WriteLine("How many players do you want in this simulation of the Monopoly ?");
            int nb_player = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many turntable to win the game ?");
            int nb_tt= Convert.ToInt32(Console.ReadLine());

            Letsplay myPlay = new Letsplay(nb_player, nb_tt);

            int res = myPlay.PlayGame();
            Console.WriteLine("The winner is the player "+res);


            Console.ReadKey();
        }
    }
}
