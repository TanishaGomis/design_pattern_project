using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Player
    {
        public int numero;
        public Box position;
        protected bool in_jail =false;
        protected int count_double=0;
        protected int jail_time=0;
        public int nb_tour=0;
        
        // BUILDER
        public Player(int num, Singleton_Board Board)
        {
            this.numero = num;
            this.position = Board.board[0];
        }

        // Function which verify of the player finished is turntable or not
        public bool finished_tour (int value_dices)
        {
            bool res = false;
            int num_future_box = position.bnum + value_dices;
            if(position.bnum<40 && num_future_box>=40)
            {
                res = true;
            }
            return res;
        }

        // Function which allow the players to throw the dice and move on the board according to the rules of the game
        public void Play(Singleton_Board Board, Random r)
        {
            // The player throw two dice 
            Dice dice1 = new Dice();
            Dice dice2 = new Dice();
            dice1.Throw(r);
            dice2.Throw(r);

            Console.WriteLine("The player "+this.numero+" throws the dice and obtains \n" + dice1.value + " " + dice2.value+"\n\n");

            int numposition; //reprensent the position on the board of the player after he throw the dice
            
            if(this.in_jail==false) //If the player is not already in jail
            {
                if (dice1.IsEqual(dice2)) // If the player obtain a double
                {
                    this.count_double = this.count_double + 1;
                    if (this.count_double == 3) // we verify that it is not its third double, if it is the case he goes to jail
                    {
                        this.in_jail = true;
                        this.position = Board.board[10];
                        this.count_double = 0;
                        Console.WriteLine("The player " + this.numero + " goes to jail !\n");
                    }
                    else // if he obtains a double 
                    {
                        numposition = this.position.bnum + dice1.value + dice2.value;
                        if(finished_tour(dice1.value+dice2.value)==true) // we verify if he finished his turntablle
                        {
                            nb_tour = nb_tour + 1;
                        }

                        this.position = Board.get_box(numposition); // we get the position on the board on the player (taking in account taht the board is composed of only 40 boxes

                        if (this.position.bnum == 30) // if the the player geos on the box 30 he goes to jail
                        {
                            this.in_jail = true;
                            this.position = Board.board[10];
                            Console.WriteLine("The player " + this.numero + " goes to jail !\n");
                        }

                        else //if the player does a double he can play again
                        {
                            Play(Board,r);
                        }

                        this.count_double = 0;
                    }
                }
                else // if the player does not obtain a double
                {
                    numposition = this.position.bnum + dice1.value + dice2.value;

                    if (finished_tour(dice1.value + dice2.value) == true)
                    {
                        nb_tour = nb_tour + 1;
                    }

                    this.position = Board.get_box(numposition);

                    if (this.position.bnum == 30)
                    {
                        this.in_jail = true;
                        this.position = Board.board[10];
                        Console.WriteLine("The player " + this.numero + " goes to jail !\n");

                    }
                }

            }

            else if (this.in_jail==true) // if the player is in jail
            {
                if(this.jail_time==2) // if he is in jail since 3 turns, he can get out and move normally on the board
                {
                    this.in_jail = false;
                    this.jail_time = 0;
                    numposition = this.position.bnum + dice1.value + dice2.value;
                    this.position = Board.get_box(numposition);
                    Console.WriteLine("The player " + this.numero + " gets out of jail !\n");
                }
                else
                {
                    if (dice1.IsEqual(dice2)) // if the player obtains a double he can get out of the jail and move normally on the board. But he does not play again
                    {
                        this.in_jail = false;
                        this.jail_time = 0;
                        numposition = this.position.bnum + dice1.value + dice2.value;
                        this.position = Board.get_box(numposition);
                        Console.WriteLine("The player " + this.numero + " gets out of jail !\n");
                    }
                    else // the player stay in prison and does not move at all
                    {
                        this.jail_time = this.jail_time + 1;
                        Console.WriteLine("The player " + this.numero + " stays in jail !\n");
                    }

                }
            }
            
        }

        public string toString()
        {
            return "######################\nNumber of the player : " + this.numero + "\nPosition of the player : " + this.position.bnum + "\nIn Jail : " + this.in_jail +"\nNumber of turntable : "+this.nb_tour+ "\n######################\n";
        }
    }

}
