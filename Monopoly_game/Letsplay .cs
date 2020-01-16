using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Letsplay
    {
        protected int nb_players;
        protected int nb_turntable_to_win;
        public Random r = new Random();
        
        // BUILDER
        public Letsplay(int players, int turn)
        {
            this.nb_players = players;
            this.nb_turntable_to_win = turn;
        }

        // Function to create the board of the game
        public Singleton_Board createBoard()
        {
            Singleton_Board myBoard = Singleton_Board.getInstance();
            for (int i = 0; i < 40; i++)
            {
                Box myBox = new Box(i);
                myBoard.add_box(myBox);
            }
            return myBoard;
        }

        // Function to create the players (which belong all to the same board in parameter) and add them in a list
        public List<Player> create_Players(Singleton_Board board)
        {
            List<Player> players = new List<Player>();
            for (int i = 0; i < nb_players; i++)
            {
                Player newPlayer = new Player(i, board);
                players.Add(newPlayer);
            }
            return players;
        }

        // Function which verify if the nuumber of turntable to win was reached by a player
        public bool finished_game(List<Player> players)
        {
            bool res = false;
            for (int i = 0; i < nb_players; i++)
            {
                if (players[i].nb_tour >= nb_turntable_to_win)
                {
                    res = true;
                }
            }
            return res;
        }


        // Function to play the game and apply the rules of it
        public int PlayGame()
        {

            Console.WriteLine("\n");
            string s = "Let's plays to the MONOPOLY game ! ";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
            Console.WriteLine("Number of players : {0}\nNumber of turntable to win : {1}\nThe player 0 begins\n", nb_players, nb_turntable_to_win);

            Singleton_Board myBoard = createBoard();
            List<Player> players = create_Players(myBoard);
            int number_winner = -1;
            int pos_winner = -1;

            while (finished_game(players) == false) // while the game is not finished, each player play his turn. Even if one player has reached the right number of turntable, he has to wait for the other players to play their last turn.
            {
                for (int i = 0; i < nb_players; i++)
                {
                    players[i].Play(myBoard, r);
                    Console.WriteLine(players[i].toString());
                    Thread.Sleep(900);
                }
            }

            for (int i = 0; i < nb_players; i++) // The winner is the player which reached the right number of turntable. If two players managed to do it, we select the one who goes farthest away
            {
                
                if(players[i].nb_tour==nb_turntable_to_win && players[i].position.bnum>pos_winner)
                {

                    number_winner = players[i].numero;
                    pos_winner = players[i].position.bnum;
                }
            }

            return number_winner;

        }
    }
}

